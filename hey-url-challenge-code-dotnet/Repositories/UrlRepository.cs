using HeyUrlChallengeCodeDotnet.Data;
using HeyUrlChallengeCodeDotnet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HeyUrlChallengeCodeDotnet.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationContext _context;

        public UrlRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext ?? throw new System.ArgumentNullException(nameof(applicationContext));
        }

        public async Task AddClicksToUrlAsync(string shortUrl, string platform, string browser, CancellationToken ct)
        {
            var url = await _context.Urls.Include(c => c.Clicks).FirstOrDefaultAsync(x => x.ShortUrl == shortUrl, ct);
            url.Clicks.Add(new Click(platform, browser) { UrlId = url.Id });

            await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Url>> GetAllAsync(CancellationToken ct) => await _context.Urls.Include(c => c.Clicks).ToListAsync(ct);

        public async Task<Url> GetByShortUrlAsync(string shortUrl, CancellationToken ct) => 
            await _context.Urls.Include(c => c.Clicks).FirstOrDefaultAsync(x => x.ShortUrl == shortUrl, ct);

        public async Task SaveAsync(Url url, CancellationToken ct)
        {
            await _context.Urls.AddAsync(url, ct);
            await _context.SaveChangesAsync(ct);
        }
    }
}
