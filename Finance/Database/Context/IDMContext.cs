using Finance.Database.Factory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finance.Database.Context
{
    public class IDMContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public IDMContext(DbContextOptions<IDMContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(b => {
                b.ToTable("Users");
                b.HasKey((e) => e.Id);
            });
            modelBuilder.Entity<IdentityRole<Guid>>(b => {
                b.ToTable("Roles");
                b.HasKey((e) => e.Id);
            });
            modelBuilder.Entity<IdentityUserClaim<Guid>>(b => b.ToTable("UserClaims"));
            modelBuilder.Entity<IdentityUserLogin<Guid>>(b => b.ToTable("UserLogins"));
            modelBuilder.Entity<IdentityUserRole<Guid>>(b => b.ToTable("UserRoles"));
            modelBuilder.Entity<IdentityUserToken<Guid>>(b => b.ToTable("UserTokens"));
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(b => b.ToTable("RoleClaims"));
        }
    }
}
