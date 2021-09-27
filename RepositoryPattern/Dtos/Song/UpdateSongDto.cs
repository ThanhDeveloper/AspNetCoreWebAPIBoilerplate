namespace RepositoryPattern.Dtos.Song
{
    public class UpdateSongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string KindOfMusic { get; set; }
        public decimal Rating { get; set; }
        public int View { get; set; }
    }
}