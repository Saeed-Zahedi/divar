namespace DBProject.Controllers.PresentationModels
{
    public class AddCustomerRequest
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string telNo { get; set; }
        public int postNO { get; set; }
        public int CID { get; set; }
        public int UStatus { get; set; }
        public DateTime date { get; set; }

        public AddCustomerRequest(string name, string lastname, string email, string telNo, int postNO, int CID, int UStatus, DateTime date)
        {
            this.name = name;
            this.lastname = lastname;
            this.email = email;
            this.telNo = telNo;
            this.postNO = postNO;
            this.CID = CID;
            this.UStatus = UStatus;
            this.date = date;
        }
    }
}
