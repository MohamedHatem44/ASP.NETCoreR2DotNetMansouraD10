using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD10.Controllers
{
    //[Authorize]
    public class TestRolesController : Controller
    {
        /*------------------------------------------------------------------*/
        [Authorize]

        public IActionResult IndexV01()
        {
            return Content("Index V01");
        }
        /*------------------------------------------------------------------*/
        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IActionResult IndexV02()
        {
            return Content("Index V02");
        }
        /*------------------------------------------------------------------*/
        [Authorize(Roles = "User")]
        public IActionResult IndexV03()
        {
            return Content("Index V03");
        }
        /*------------------------------------------------------------------*/
    }
}
