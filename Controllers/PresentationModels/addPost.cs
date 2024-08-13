using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;

namespace DBProject.Controllers.PresentationModels
{
    public class addPost
    {
        public string title { get; set; }
        public string body { get; set; }
        public int ownerID { get; set; }
        public int BTID { get; set; }
        public int CID { get; set; }
        public long price { get; set; }

        public addPost(string title, string body, int ownerID, int BTID, int CID, long price) {

            this.title = title;
            this.body = body;
            this.ownerID = ownerID;
            this.BTID = BTID;
            this.CID = CID;
            this.price = price;
                
        }    
    }
}
