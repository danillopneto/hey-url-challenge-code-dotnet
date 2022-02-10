using System;

namespace HeyUrlChallengeCodeDotnet.Models.Base
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
