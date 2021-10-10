namespace AspNetCoreTemplate.Domain.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string KindOfMusic { get; set; }
        public decimal Rating { get; set; }
        public int View { get; set; }

        public Song() { }

        public Song(int id, string name, string author, string kindOfMusic, decimal rating, int view) 
        {
            Id = id;
            Name = name;
            Author = author;
            KindOfMusic = kindOfMusic;
            Rating = rating;
            View = view;
        }
    }
}
