using System.Collections.Generic;
using System.Web.Http;
using WebApiCastleIntegration.Dependencies;

namespace WebApiCastleIntegration.Controllers
{
    public class ValuesController : ApiController
    {
        public IMessageSource MessageSource { get; set; }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return string.Format("{0} - id:{1}", MessageSource.GetMessage(), id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}