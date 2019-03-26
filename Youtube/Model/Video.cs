using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Interfaces;

namespace Youtube.Model
{
    public class Video : IMultimedia
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
    }
}
