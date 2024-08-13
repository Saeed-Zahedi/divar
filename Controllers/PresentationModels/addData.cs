namespace DBProject.Controllers.PresentationModels
{
    public class addData
    {
        public int PID { get; set; }
        public string key { get; set; }
        public string value { get; set; }

        public addData(int PID,string key, string value)
        {
            this.PID = PID;
            this.key = key;
            this.value = value;
        }
    }
}
