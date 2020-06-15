using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.DAL.Entities;
using RealEstateIdentity.ViewModels;

namespace RealEstateIdentity.Controllers
{
    [Route("api/roles")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNewRoleViewModel Role)
        {
            if (!string.IsNullOrEmpty(Role.Name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(Role.Name));
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return BadRequest();
        }
    }
}
