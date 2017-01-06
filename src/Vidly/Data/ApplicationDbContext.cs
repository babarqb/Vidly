using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole<string>,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(e => e.ToTable("Users").HasKey(x => x.Id));

            builder.Entity<IdentityRole<string>>(e => e.ToTable("Roles").HasKey(x => x.Id));

            builder.Entity<IdentityRoleClaim<string>>(e => e.ToTable("RoleClaim").HasKey(x => x.Id));

            builder.Entity<IdentityUserRole<string>>(e => e.ToTable("UserRoles").HasKey(x => x.RoleId));

            builder.Entity<IdentityUserLogin<string>>(e => e.ToTable("UserLogin").HasKey(x => x.UserId));

            builder.Entity<IdentityUserClaim<string>>(e => e.ToTable("UserClaims").HasKey(x => x.Id));

            builder.Entity<IdentityUserToken<string>>(e => e.ToTable("UserTokens").HasKey(x => x.UserId));
        }
    }
}
