namespace DBProject.Controllers.PresentationModels
{
    public class AddAddressReq
    {
        public int CID { get; set; }
        public string FAddress { get; set; }
        public AddAddressReq(int CID, string FAddress)
        {
            this.CID = CID;
            this.FAddress = FAddress;
        }
    }
}
