using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WC.BOL.DTO;
using WC.BOL.Services;

namespace WC.RestApi.Controllers
{
    public class ValuesController : ApiController
    {
        IEntityService<LogDataDTO> repository;

        public ValuesController(IEntityService<LogDataDTO> repository)
        {
            this.repository = repository;
        }

        // GET api/values
        public IHttpActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            LogDataDTO logData = repository.Get(id);
            if (logData == null)
                return NotFound();//Request.CreateResponse(HttpStatusCode.NotFound, "Not Found")
            return Ok(logData);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]LogDataDTO logData)
        {
            if (logData == null)
            {
                string text = string.Format("Nothing to save");
                HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.NoContent, text);
                return msg;
            }
            else
            {
                repository.AddOrUpdate(logData);
                string tmp = string.Format($"{logData.LogId} has been saved");
                HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, tmp);
                string url = Url.Link("DefaultApi", new { id = logData.LogId });
                message.Headers.Location = new Uri(url);
                return message;
            }
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
