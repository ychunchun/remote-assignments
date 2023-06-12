using Microsoft.AspNetCore.Mvc;

namespace Calculate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] int number)
        {
            int result = CalculateSum(number);
            return Ok(result);
        }

        private int CalculateSum(int number)
        {
            int sum = 0;
            for (int i = 1; i <= number; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
