namespace DBProject.Controllers.PresentationModels
{
    public class addPicture 
    { 
        public int postId { get; set; }
        public string link { get; set; }

        public addPicture(int postId, string link) {
            this.postId = postId;
            this.link = link;
        }
    }
}
