using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Album:Artist
    {
        public string nameAlbum { get; set; }
        public List<Track> tracks { get; set; }
    }
}
