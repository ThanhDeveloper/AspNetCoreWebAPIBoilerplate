using System;

namespace RepositoryPattern.Domain.Entities
{
    public class Song
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string kind_of_music { get; set; }
        public decimal rating { get; set; }
        public int view { get; set; }

        public Song() { }

        public Song(int id, string name, string author, string kind_of_music, decimal rating, int view) 
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.kind_of_music = kind_of_music;
            this.rating = rating;
            this.view = view;
        }
    }
}
