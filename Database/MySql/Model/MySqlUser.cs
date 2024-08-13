namespace DBProject.Database.MySql.Model
{
    public class MySqlUser
    {
        public int UID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; } 
        public string email { get; set; }
        public string telNo { get; set; }
        public int postNo { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int UStatus { get; set; }
        public DateTime date { get; set; }
        
    }
}
