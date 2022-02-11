using HeyUrlChallengeCodeDotnet.Models;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;
using System;

namespace HeyUrlChallengeCodeDotnet.Controllers
{
    public class UrlsApiController : JsonApiController<Url, Guid>
    {
        public UrlsApiController(
                                 IJsonApiOptions options,
                                 ILoggerFactory loggerFactory,
                                 IResourceService<Url, Guid> resourceService)
            : base(options, loggerFactory, resourceService)
        {
            //https://localhost:5001/api/v1/url?include=clicks&sort=-createdAt&page[size]=10&page[number]=1
        }
    }
}
