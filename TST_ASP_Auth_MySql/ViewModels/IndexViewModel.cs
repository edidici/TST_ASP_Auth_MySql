using System.Collections.Generic;
using TST_ASP_Auth_MySql.Models;

namespace TST_ASP_Auth_MySql.ViewModels
{
    /// <summary>
    /// Defines the class of Index View Model
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the name of the user role.
        /// </summary>
        /// <value>
        /// The name of the user role.
        /// </value>
        public string UserRoleName { get; set; }

        /// <summary>
        /// Gets or sets all users.
        /// </summary>
        /// <value>
        /// All users.
        /// </value>
        public List<UserViewModel> AllUsers { get; set; }
    }
}