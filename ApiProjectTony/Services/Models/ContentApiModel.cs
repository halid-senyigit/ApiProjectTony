namespace ApiProjectTony.Services.Models
{
    public class Meta
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Image
    {
        public string path { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string mime { get; set; }
        public Meta meta { get; set; }
        public string url { get; set; }
    }

    public class ContentApiModel
    {
        public int id { get; set; }
        public object created_at { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }
        public Image image { get; set; }
    }


}
