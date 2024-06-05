using LoginExample.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoginExample.Models.Models;
using Microsoft.Extensions.Configuration;

namespace LoginExample.Dal.EFC
{
    public class ApplicationDbContextEFC : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<DeviceSession> DeviceSessions { get; set; }
        #endregion
    }
}
