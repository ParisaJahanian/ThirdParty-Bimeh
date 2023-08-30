using Bimeh.Entities;
using CarElectronicTolls.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace persistence
{
    public class FireDbContext :DbContext
    {
        public DbSet<FireReqLog> FireReqLogs{ get; set; }
        public DbSet<FireResLog> FireResLogs { get; set; }
        public DbSet<FireInsuranceLog> FireInsuranceLogs{ get; set; }
        public DbSet<AccessTokenEntity> AccessTokens { get; set; }

        public FireDbContext(DbContextOptions<FireDbContext> dbContext) : base(dbContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FireDbContext).Assembly);
        }


    }
}