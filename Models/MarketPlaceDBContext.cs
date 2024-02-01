using Microsoft.EntityFrameworkCore;
using ProjectMarketPlace.Models;

namespace ProjectMarketPlace.Models
{
    public partial class MarketPlaceDBContext : DbContext
    {
        public MarketPlaceDBContext()
        {

        }
        public MarketPlaceDBContext(DbContextOptions<MarketPlaceDBContext> options) : base(options)
        {

        }
        public virtual DbSet<UserEntity> UserEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
