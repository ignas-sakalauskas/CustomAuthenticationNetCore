using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuthNetCore20.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            var claimValues = HttpContext.User.Claims.Select(c => c.Value);
            return Ok(claimValues);
        }
    }
}
