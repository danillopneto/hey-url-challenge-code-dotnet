using HeyUrlChallengeCodeDotnet.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HeyUrlChallengeCodeDotnet.Repositories
{
    public interface IUrlRepository
    {
        Task AddClicksToUrlAsync(Url url, string platform, string browser, CancellationToken ct);

        Task<IEnumerable<Url>> GetAllAsync(CancellationToken ct);

        Task<Url> GetByShortUrlAsync(string shortUrl, CancellationToken ct);

        Task SaveAsync(Url url, CancellationToken ct);
    }
}
