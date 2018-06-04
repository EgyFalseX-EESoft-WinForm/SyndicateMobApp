using System.Runtime.Serialization;

namespace SyndicateMobApp.Services
{
    [DataContract]
    public class NewsItemContrect
    {
        public NewsItemContrect(int News_id, string Subject, string Image_path, string Contain)
        {
            news_id = News_id;
            subject = Subject;
            image_path = Image_path;
            contain = Contain;
        }
        [DataMember]
        public int news_id { get; set; }
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string image_path { get; set; }
        [DataMember]
        public string contain { get; set; }
    }
}
