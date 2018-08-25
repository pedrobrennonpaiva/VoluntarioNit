using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VoluntarAe.Controllers
{
    public class ColaboryController : ApiController
    {
        // GET: api/Colabory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Colabory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Colabory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Colabory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Colabory/5
        public void Delete(int id)
        {
        }
    }
}
