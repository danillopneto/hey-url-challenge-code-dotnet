using FluentValidation;
using HeyUrlChallengeCodeDotnet.Models;
using System;

namespace HeyUrlChallengeCodeDotnet.Validators
{
    public class UrlValidator : AbstractValidator<Url>
    {
        public UrlValidator()
        {
            RuleFor(x => x.OriginalUrl)
                .NotEmpty()
                .WithMessage("Please, provide a url.");

            RuleFor(x => x.OriginalUrl)
                .Must(IsUrl)
                .When(x => !string.IsNullOrWhiteSpace(x.OriginalUrl))
                .WithMessage("Please, provide a valid url.");
        }

        private bool IsUrl(string url) => Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}
