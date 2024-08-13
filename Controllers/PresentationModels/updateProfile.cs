using Org.BouncyCastle.Bcpg.OpenPgp;

namespace DBProject.Controllers.PresentationModels
{
    public class updateProfile
    {
        public string name { get; set; }
        public int CID { get; set; }
        public string telNO { get; set; }

        public updateProfile(string name, int cID, string telNO)
        {
            this.name = name;
            CID = cID;
            this.telNO = telNO;
        }
    }
}
