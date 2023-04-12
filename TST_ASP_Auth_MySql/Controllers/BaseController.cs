using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TST_ASP_Auth_MySql.Models;

namespace TST_ASP_Auth_MySql.Controllers
{
    /// <summary>
    /// Defines the class of Base Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class BaseController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger<BaseController> Logger;

        /// <summary>
        /// The database context
        /// </summary>
        protected readonly UsersDbContext Db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="context">The context.</param>
        public BaseController(ILogger<BaseController> logger, UsersDbContext context)
        {
            Logger = logger;
            Db = context;
        }
    }
}