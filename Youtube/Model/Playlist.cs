using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Interfaces;

namespace Youtube.Model
{
    public class Playlist : IMultimedia
    {
        public string PlaylistId { get; set; }
        public string Title { get; set; }
    }
}
