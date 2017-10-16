using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mylib;

namespace src.Controllers
{
    [Route("api/[controller]")]
    public class AddController : Controller
    {
        private readonly ICalc m_calc;

        public AddController(ICalc calc)
        {
            m_calc = calc;
        }

        /// <summary>
        /// Get the result of the sum from a and b parameters.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: api/add/2/2
        ///
        /// </remarks>
        /// <param name="a">a integer number</param>
        /// <param name="b">a integer number</param>
        /// <returns>the sum from the a and b parameters</returns>
        /// <response code="200">if the sum can be done with success</response>
        /// <response code="500">for any exception</response>  
        [HttpGet("{a}/{b}")]
        public async Task<IActionResult> Get(int a, int b)
        {
            int result = await m_calc.AddAsync(a, b).ConfigureAwait(false);

            string responseMessage = $"{Environment.MachineName}-Result: {result}";

            return Ok(responseMessage);
        }

        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
