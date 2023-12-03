using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FastWeb.Infrastructure.Services;

internal class RequestLocalizationOptionsPostConfigure : IPostConfigureOptions<RequestLocalizationOptions>
{
    private readonly IConfiguration _configuration;

    public RequestLocalizationOptionsPostConfigure(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void PostConfigure(string? name, RequestLocalizationOptions options)
    {
        var cultures = _configuration.GetSection(nameof(Cultures)).Get<Cultures>();
        if (cultures is null)
        {
            return;
        }

        if (!string.IsNullOrWhiteSpace(cultures.Default))
        {
            options.SetDefaultCulture(cultures.Default);
        }
        options.AddSupportedCultures(cultures.Supported);
        options.AddSupportedCultures(cultures.UISupported);
        options.ApplyCurrentCultureToResponseHeaders = true;
    }

    class Cultures
    {
        public string? Default { get; set; }
        public string[] Supported { get; set; } = Array.Empty<string>();
        public string[] UISupported { get; set; } = Array.Empty<string>();
    }
}
