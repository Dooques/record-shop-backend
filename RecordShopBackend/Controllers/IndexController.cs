using Microsoft.AspNetCore.Mvc;

namespace RecordShopBackend.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController
    {
        [HttpGet]
        public string Get()
        {
            return "This is the Record Shop Index";
        }
    }
}
