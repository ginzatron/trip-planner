using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DbContexts
{
    public class TravelPlanningContext : DbContext
    {
        public TravelPlanningContext(DbContextOptions<TravelPlanningContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<TripDetails> TripDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TripDetails>()
                .HasIndex(t => t.UserId);
        }
    }
}
