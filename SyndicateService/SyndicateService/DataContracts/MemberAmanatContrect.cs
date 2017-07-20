using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SyndicateServiceLib.DataContracts
{
    [DataContract]
    public class MemberAmanatContrect
    {
        public MemberAmanatContrect(int _MMashatId
            , int _DofatSarfAId
            , byte _amanattypeid
            , double _amanatmony
            , string _amanatrem
            , int _userin
            , DateTime _datein
            , double _estktaa
            , string _mostahek
            , int _DofatSarfId
            , string _sefa
            , bool _accReview
            , DateTime _dateReview
            , int _useracc
            , bool _amantvisa
            , bool _sarfcheek
            , string _cheekno
            , DateTime _tasleemdate
            , string _mostlemsheek
            , int _userincheek
            , DateTime _datincheek
            , int _AutoId)
        {
            MMashatId = _MMashatId;
            DofatSarfAId = _DofatSarfAId;
            amanattypeid = _amanattypeid;
            amanatmony = _amanatmony;
            amanatrem = _amanatrem;
            userin = _userin;
            datein = _datein;
            estktaa = _estktaa;
            mostahek = _mostahek;
            DofatSarfId = _DofatSarfId;
            sefa = _sefa;
            accReview = _accReview;
            dateReview = _dateReview;
            useracc = _useracc;
            amantvisa = _amantvisa;
            sarfcheek = _sarfcheek;
            cheekno = _cheekno;
            tasleemdate = _tasleemdate;
            mostlemsheek = _mostlemsheek;
            userincheek = _userincheek;
            datincheek = _datincheek;
            AutoId =_AutoId;
        }
        

        [DataMember]
        public int MMashatId{ get; set; }
        [DataMember]
        public int DofatSarfAId { get; set; }
        [DataMember]
        public byte amanattypeid { get; set; }
        [DataMember]
        public double amanatmony { get; set; }
        [DataMember]
        public string amanatrem { get; set; }
        [DataMember]
        public int userin { get; set; }
        [DataMember]
        public DateTime datein { get; set; }
        [DataMember]
        public double estktaa { get; set; }
        [DataMember]
        public string mostahek { get; set; }
        [DataMember]
        public int DofatSarfId { get; set; }
        [DataMember]
        public string sefa { get; set; }
        [DataMember]
        public bool accReview { get; set; }
        [DataMember]
        public DateTime dateReview { get; set; }
        [DataMember]
        public int useracc { get; set; }
        [DataMember]
        public bool amantvisa { get; set; }
        [DataMember]
        public bool sarfcheek { get; set; }
        [DataMember]
        public string cheekno { get; set; }
        [DataMember]
        public DateTime tasleemdate { get; set; }
        [DataMember]
        public string mostlemsheek { get; set; }
        [DataMember]
        public int userincheek { get; set; }
        [DataMember]
        public DateTime datincheek { get; set; }
        [DataMember]
        public int AutoId { get; set; }
    }
}
