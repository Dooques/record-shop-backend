using Microsoft.AspNetCore.Mvc;

namespace RecordShopBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController
    {
        [HttpGet]
        public string Get()
        {
            return "This is the Record Shop Index";
        }
    }
}
