using HeyUrlChallengeCodeDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyUrlChallengeCodeDotnet.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Click> Clicks { get; set; }

        public DbSet<Url> Urls { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>()
                        .ToTable(nameof(Url))
                        .HasMany<Click>()
                        .WithOne(c => c.Url)
                        .HasForeignKey(c => c.UrlId)
                        .IsRequired();

            modelBuilder.Entity<Url>()
                        .HasIndex(u => u.ShortUrl)
                        .IsUnique();

            modelBuilder.Entity<Click>()
                        .ToTable(nameof(Click));

            base.OnModelCreating(modelBuilder);
        }
    }
}
