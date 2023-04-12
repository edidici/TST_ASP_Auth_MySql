using System;
using Microsoft.EntityFrameworkCore;

namespace TST_ASP_Auth_MySql.Models
{
    /// <summary>
    /// Defines the class of Users Database Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class UsersDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options)
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminRole = new Role { Id = Guid.NewGuid(), Name = "admin" };
            var userRole = new Role { Id = Guid.NewGuid(), Name = "user" };
            var adminUser = new User { Id = Guid.NewGuid(), Email = "admin@mail.ru", Password = "123", RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(adminRole, userRole);
            modelBuilder.Entity<User>().HasData(adminUser);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Recreates the database base entities.
        /// </summary>
        public void RecreateDbBaseEntities()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}