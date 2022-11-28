using Microsoft.AspNetCore.Mvc;

namespace ListifyCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListifyController : ControllerBase
    {
        //static int m_first = 100;
        //static int m_second = 200;
        //static Listify m_listify = new Listify(m_first, m_second);


        private readonly ILogger<ListifyController> _logger;

        public ListifyController(ILogger<ListifyController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{first:int:min(0)}/{second:int:min(0)}/{index:int:min(0)}")]
        public ObjectResult Get(int first, int second, int index)
        {
            try
            {
                if (first > second)
                    return new ObjectResult("Upper limit of range should be greater than lower limit.");

                //m_first = first;
                //m_second = second;

                if (index > second - first)
                    return new ObjectResult("Index out of range.");

                //m_listify = new Listify(first, second);
                var listify = new Listify(first, second);

                return new ObjectResult(listify[index]);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }
        }

        //[HttpGet("{index:int:range(0, 100)}")]
        //public ObjectResult Get(int index)
        //{
        //    try
        //    {
        //        return new ObjectResult(new { Value = m_listify[index], Desc = "Success" });
        //    }
        //    catch (Exception e)
        //    {
        //        return new ObjectResult(new { Value = "NaN", Desc = e.Message });
        //    }
        //}
    }
}