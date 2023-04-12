using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TST_ASP_Auth_MySql.Models;
using TST_ASP_Auth_MySql.ViewModels;

namespace TST_ASP_Auth_MySql.Controllers
{
    /// <summary>
    /// Defines the class of Home Controller
    /// </summary>
    /// <seealso cref="TST_ASP_Auth_MySql.Controllers.BaseController" />
    public class HomeController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public HomeController(ILogger<BaseController> logger, UsersDbContext context) : base(logger, context)
        {
        }

        /// <summary>
        /// Shows the index view.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                UserName = User.Identity.Name,
                UserRoleName = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value,
                AllUsers = Db.Users.Select(p => new UserViewModel {Id = p.Id, Email = p.Email, Avatar = p.Avatar}).ToList()
            };

            return View(model);
        }

        /// <summary>
        /// Deletes the user by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                var user = await Db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    Db.Users.Remove(user);
                    await Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }

        /// <summary>
        /// Shows the Error view.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}