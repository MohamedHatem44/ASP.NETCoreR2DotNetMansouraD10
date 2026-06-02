using ASP.NETCoreD10.Models;
using ASP.NETCoreD10.ViewModels.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASP.NETCoreD10.Controllers
{
    public class RolesController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly RoleManager<ApplicationRole> _roleManager;
        /*------------------------------------------------------------------*/
        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleVM createRoleVM)
        {
            if(!ModelState.IsValid)
            {
                return View(createRoleVM);
            }

            ApplicationRole applicationRole = new ApplicationRole
            {
                Name = createRoleVM.Name,
            };

            var result = await _roleManager.CreateAsync(applicationRole);
            if(!result.Succeeded)
            {
                return View(createRoleVM);
            }

            return RedirectToAction("Index", "Home");
        }
        /*------------------------------------------------------------------*/
    }
}
