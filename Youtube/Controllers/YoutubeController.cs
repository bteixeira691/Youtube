using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Youtube.Interfaces;
using Youtube.Model;

namespace Youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private IYoutubeAPI _youtubeAPI;
        public YoutubeController(IYoutubeAPI youtubeAPI)
        {
            _youtubeAPI = youtubeAPI;
        }
        // GET: api/Youtube
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Youtube/string/int
        [HttpGet("{id}/{max}")]
        public async Task<List<IMultimedia>> Get(string id, int max)
        {
            return await _youtubeAPI.youtubeSearch(id, max);
        }


        [HttpGet("subs/{name}")]
        public async Task<Channels> Get(string name)
        {
            var max =50;
            return await _youtubeAPI.youtubeSubs(name, max);
        }

        // POST: api/Youtube
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Youtube/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
