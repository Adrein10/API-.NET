using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AdreinContext context;

        public ValuesController(AdreinContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public JsonResult list()
        {
            var show = context.Users.ToList();

			return new JsonResult(Ok(show));
		}
        [HttpPost]
         public JsonResult create(User user)
        {
            context.Users.Add(user);
			context.SaveChanges();

			return new JsonResult(Ok("User Successfully Registered"));
		}
	}
    }

