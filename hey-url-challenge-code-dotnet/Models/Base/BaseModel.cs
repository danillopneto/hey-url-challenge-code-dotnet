using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System;

namespace HeyUrlChallengeCodeDotnet.Models.Base
{
    public abstract class BaseModel : Identifiable<Guid>
    {
        [Attr]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
