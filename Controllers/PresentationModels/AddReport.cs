namespace DBProject.Controllers.PresentationModels
{
    public class AddReport
    {
        public int PID { get; set; }
        public string description { get; set; }
        public int UID { get; set; }
        public Boolean Rstatus { get; set; }
        public int RTID { get; set; }
        public int AdminId { get; set; }

        public AddReport(int PID, string description, int UID, Boolean RStatus, int RTID,int AdminId)
        {
            this.PID = PID;
            this.description = description;
            this.UID = UID;
            this.Rstatus = RStatus;
            this.RTID = RTID;
            this.AdminId = AdminId;
        }
    }
}
