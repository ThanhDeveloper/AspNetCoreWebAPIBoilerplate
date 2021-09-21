using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class SongRequest
    {
        public string name { get; set; }
        public string author { get; set; }
        public string kind_of_music { get; set; }
        public decimal rating { get; set; }
        public int view { get; set; }
    }
}
