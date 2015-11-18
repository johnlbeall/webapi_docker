using System;
using System.Web.Http;
using System.Collections;
using System.Collections.Generic;

namespace WebApiControllers
{
	public class HelloController: ApiController 
	{ 
		// GET api/values 
        [HttpGet]
        [Route("api/hello/")]
        public IEnumerable<string> Get() 
		{ 
			return new string[] { "value1", "value2" }; 
		} 

		// GET api/values/5 
        [HttpGet]
        [Route("api/hello/{id}")]
        public string Get(int id) 
		{ 
			return "value"; 
		} 

		// POST api/values 
        [HttpPost]
        [Route("api/hello/")]
        public void Post([FromBody]string value) 
		{ 
		} 

		// PUT api/values/5 
        [HttpPut]
        [Route("api/hello/{id}")]
        public void Put(int id, [FromBody]string value) 
		{ 
		} 

		// DELETE api/values/5 
        [HttpDelete]
        [Route("api/hello/{id}")]
        public void Delete(int id) 
		{ 
		} 
	}
}

