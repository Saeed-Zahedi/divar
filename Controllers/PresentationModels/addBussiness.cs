using Org.BouncyCastle.Tls;

namespace DBProject.Controllers.PresentationModels
{
    public class addBussiness
    {
        public int addressId { get; set; }
        public string name { get; set; }
        public int bussinessNO { get; set; }
        public int bussinessTypeId { get; set; }
        public int UID { get; set; }

        public addBussiness(int addressId, string name, int bussinessNO, int bussinessTypeId, int UID)
        {
            this.addressId = addressId;
            this.name = name;
            this.bussinessNO = bussinessNO;
            this.bussinessTypeId = bussinessTypeId;
            this.UID = UID;
        }   
    }
}
