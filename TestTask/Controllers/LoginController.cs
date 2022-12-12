using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly TT_DB_Context _context;
        public LoginController(TT_DB_Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> BuyerLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Buyer buyer = await _context.Buyers.FirstOrDefaultAsync(x => x.Name == model.Name && x.Password == model.Password);
                if (buyer != null)
                {
                    await Authenticate(buyer);

                    return Ok("Login success");
                }
            }
            return BadRequest();
        }

        private async Task Authenticate(Buyer buyer)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, buyer.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public async Task<IActionResult> BuyerLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
