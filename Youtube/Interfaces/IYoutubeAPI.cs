using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Model;

namespace Youtube.Interfaces
{
    public interface IYoutubeAPI
    {
        Task<List<IMultimedia>> youtubeSearch(string name, int max);
        Task<Channels> youtubeSubs(string name, int max);
    }
}
