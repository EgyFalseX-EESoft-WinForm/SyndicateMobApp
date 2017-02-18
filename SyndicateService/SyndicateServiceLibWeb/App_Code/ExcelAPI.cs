using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Excel_VBA = Microsoft.Office.Interop.Excel;

namespace SyndicateServiceLibWeb
{
/// <summary>
/// Summary description for ExcelAPI
/// </summary>
    public class ExcelAPI
    {
        public ExcelAPI()
        {
            //
            // TODO: Add constructor logic here
            //
            
        }

        public static DataTable LoadExcelFile_VBA(string strFile, int sheetIndex, string ColumnsNames)
        {
            DataTable dt = new DataTable();
        
            try
            {
                Excel_VBA.Application xlApp;
                Excel_VBA.Workbook xlWorkBook;
                Excel_VBA.Worksheet xlWorkSheet;
                Excel_VBA.Range range;

                int rCnt = 0;
                int cCnt = 0;

                xlApp = new Excel_VBA.Application();
                xlWorkBook = xlApp.Workbooks.Open(strFile, 0, true, 5, "", "", true, Excel_VBA.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel_VBA.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;
                int colCount = range.Columns.Count;
                int rowCount = range.Rows.Count;
                if (rowCount <= 1)
                    return dt;
                for (int colInx = 1; colInx <= colCount; colInx++)
                {
                    string colname = GetValidColumnName(Convert.ToString((range.Cells[1, colInx] as Excel_VBA.Range).Value), dt.Columns);
                    object TypeName = (object)(range.Cells[2, colInx] as Excel_VBA.Range).Value;
                    dt.Columns.Add(colname, TypeName == null ? typeof(string) : (TypeName).GetType());
                }
                string address = range.get_Address();
                string[] cells = address.Split(new char[] { ':' });
                string beginCell = cells[0].Replace("$", "");
                string endCell = cells[1].Replace("$", "");
            
                object[,] objectArray = (object[,])xlWorkSheet.get_Range(beginCell + ":" + endCell).Value;
                for (rCnt = 2; rCnt <= rowCount; rCnt++)
                {
                    DataRow row = dt.NewRow();
                    for (cCnt = 1; cCnt <= colCount; cCnt++)
                    {
                        string type1;
                        if (objectArray[rCnt, cCnt] != null)
                        {
                            type1 = objectArray[rCnt, cCnt].GetType().ToString();
                        }
                        string type2 = dt.Columns[cCnt - 1].DataType.ToString();
                        if (objectArray[rCnt, cCnt] != null && (objectArray[rCnt, cCnt].GetType() == dt.Columns[cCnt - 1].DataType || dt.Columns[cCnt - 1].DataType == typeof(string)))
                            row[cCnt - 1] = objectArray[rCnt, cCnt];
                    }
                    dt.Rows.Add(row);
                }
                objectArray = null;
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return dt;
        }
        private static string GetValidColumnName(string colname, DataColumnCollection cols)
        {
            bool NameInUse = false;
            foreach (DataColumn col in cols)
            {
                if (col.ColumnName == colname)
                {
                    NameInUse = true;
                    break;
                }
            }
            if (!NameInUse)
                return colname;

            for (int i = 1; i < 255; i++)
            {
                bool nameExists = false;
                foreach (DataColumn col in cols)
                {
                    if (col.ColumnName == colname + i)
                    {
                        nameExists = true;
                        break;
                    }
                }
                if (!nameExists)
                {
                    colname = colname + i;
                    break;
                }
            }
            return colname;
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


    }
}