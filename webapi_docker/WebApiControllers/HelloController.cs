using System;
using System.Web.Http;
using System.Collections;
using System.Collections.Generic;

namespace WebApiControllers
{
    /// <summary>
    /// Hello world test controller
    /// </summary>
    public class HelloController: ApiController 
	{ 
		// GET api/values 
        /// <summary>
        /// get an enumaation
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        [HttpGet]
        [Route("api/hello/")]
        public IEnumerable<string> Get() 
		{ 
			return new string[] { "value1", "value2" }; 
		} 

        /// <summary>
        /// Get a specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string value</returns>
		// GET api/values/5 
        [HttpGet]
        [Route("api/hello/{id}")]
        public string Get(int id) 
		{ 
			return "value"; 
		} 

		// POST api/values 
        /// <summary>
        /// post some data
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("api/hello/")]
        public void Post([FromBody]string value) 
		{ 
		} 

		// PUT api/values/5 
        /// <summary>
        /// put some data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut]
        [Route("api/hello/{id}")]
        public void Put(int id, [FromBody]string value) 
		{ 
		} 

		// DELETE api/values/5 
        /// <summary>
        /// delete some item
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("api/hello/{id}")]
        public void Delete(int id) 
		{ 
		} 
	}
}

