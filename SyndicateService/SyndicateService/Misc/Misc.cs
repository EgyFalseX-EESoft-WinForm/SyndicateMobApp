using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateServiceLib.Misc
{
    public class Misc
    {
        public static int UnlimitedTimeOut = 0;
        public static void SetAllCommandTimeouts(object adapter, int timeout)
        {
            var commands = adapter.GetType().InvokeMember("CommandCollection",
                    System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                    null, adapter, new object[0]);
            var sqlCommand = (System.Data.IDbCommand[])commands;
            foreach (var cmd in sqlCommand)
            {
                cmd.CommandTimeout = timeout;
            }
        }
    }
}
