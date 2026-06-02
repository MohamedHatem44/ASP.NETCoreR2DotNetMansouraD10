using ASP.NETCoreD10.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreD10.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        /*------------------------------------------------------------------*/
        public AppDbContext() : base()
        {
        }
        /*------------------------------------------------------------------*/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        /*------------------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>()
            //    .Property(u => u.UserName)
            //    .HasMaxLength(100);

            //builder.Entity<IdentityUser>()
            //   .Property(u => u.UserName)
            //   .HasMaxLength(100);

            //builder.Entity<IdentityRole>()
            //   .Property(u => u.Name)
            //   .HasMaxLength(100);
        }
        /*------------------------------------------------------------------*/
    }
}
