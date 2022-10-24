using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MedicalService.Auth.Data
{
    public class MedicalServiceIdentityDbContext : IdentityDbContext<ApplicationUser,
        IdentityRole<Guid>,
        Guid,
        IdentityUserClaim<Guid>,
        IdentityUserRole<Guid>,
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>>
    {
        public MedicalServiceIdentityDbContext(DbContextOptions<MedicalServiceIdentityDbContext> options)
            : base(options)
        {
        }

        public MedicalServiceIdentityDbContext() : this(new DbContextOptionsBuilder<MedicalServiceIdentityDbContext>().Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicalServiceIdentityDbContext).Assembly);
        }
    }
}