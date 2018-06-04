using System.Runtime.Serialization;

namespace SyndicateMobApp.Services
{
    [DataContract]
    public class NewsFrontPageContrect
    {
        public NewsFrontPageContrect(int News_id, string Subject, string Image_path)
        {
            news_id = News_id;
            subject = Subject;
            image_path = Image_path;
        }
        [DataMember]
        public int news_id { get; set; }
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string image_path { get; set; }
    }
}
