namespace src.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using mylib;

    /// <summary>
    /// Controller to handle sum operations.
    /// </summary>
    [Route("api/[controller]")]
    public class AddController : Controller
    {
        private readonly ICalc m_calc;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="calc"></param>
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
    }
}
