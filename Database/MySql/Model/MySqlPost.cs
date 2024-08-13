using Org.BouncyCastle.Asn1.Crmf;

namespace DBProject.Database.MySql.Model
{
    public class MySqlPost
    {
        public string title { get; set; }
        public string body { get; set; }
        public int viewNO { get; set; }
        public int OwnerID { get; set; }
        public int BtID { get; set; }
        public DateTime date { get; set; }
        public bool IsUser { get; set; }
        public int CID { get; set; }
        public bool poststatus { get; set; }
        public long price { get; set; }
        public string cityName { get; set; }
        public string BTName { get; set; }  
    }

}
