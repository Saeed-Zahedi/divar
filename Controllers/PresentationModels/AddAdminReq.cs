namespace DBProject.Controllers.PresentationModels
{
    public class AddAdminReq
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string telNo { get; set; }
        public string password { get; set; }

        public AddAdminReq(string name, string lastname, string email, string telNo, string password)
        {
            this.name = name;
            this.lastname = lastname;
            this.email = email;
            this.telNo = telNo;
            this.password = password;
        }
    }
}
