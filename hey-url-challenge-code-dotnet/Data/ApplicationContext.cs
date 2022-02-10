using HeyUrlChallengeCodeDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyUrlChallengeCodeDotnet.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
    }
}