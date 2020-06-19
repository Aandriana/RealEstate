//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace RealEstateIdentity.Controllers
//{
//    [Route("api/roles")]
//    public class RolesController : Controller
//    {
//        RoleManager<IdentityRole> _roleManager;

//        public RolesController(RoleManager<IdentityRole> roleManager)
//        {
//            _roleManager = roleManager;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create()
//        {
//            await _roleManager.CreateAsync(new IdentityRole("User"));
//            await _roleManager.CreateAsync(new IdentityRole("Agent"));
//            return Ok();
//        }
//    }
//}
