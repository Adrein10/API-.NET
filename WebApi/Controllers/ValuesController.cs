using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var show = await context.Users.FirstOrDefaultAsync(option => option.Id == id);
            if (show == null)
            {
                return NotFound();
            }
            context.Users.Remove(show);
            context.SaveChangesAsync();
            return Ok(show.Name + " User Deleted Succesfully");
        }
        
            [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id ,User user)
        {
            var show = await context.Users.FirstOrDefaultAsync(option => option.Id == id);
            if (show == null)
            {
                return NotFound();
            }
            show.Name = user.Name;
            show.Email = user.Email;
            show.Password = user.Password;
            show.Phone = user.Phone;
            context.Users.Update(show);
            context.SaveChangesAsync();

            return Ok("User Successfully Updated");
        }
    }
    }

