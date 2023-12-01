using FastEndpoints;
using FastEndpoints.Swagger;
using Ling.Core;
using Ling.Infrastructure;
using Ling.Infrastructure.Services;
using Ling.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureExtensions
{
    private static readonly Action<JsonSerializerOptions> _jsonSerializerOptionsSetup = o =>
    {
        o.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        o.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        o.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
    };

    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        var assembly = new[]
        {
            typeof(CoreAssembly).Assembly,
            typeof(InfrastructureAssembly).Assembly,
        };

        services.AddFastEndpoints(o =>
        {
            o.Assemblies = assembly;
            o.IncludeAbstractValidators = true;
        });

        services.SwaggerDocument(o =>
        {
            o.AutoTagPathSegmentIndex = 2;
            o.SerializerSettings = _jsonSerializerOptionsSetup;
        });

        services.AddAutoMapper(assembly);

        services.Configure<RequestLocalizationOptions>(delegate { });
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<RequestLocalizationOptions>, RequestLocalizationOptionsPostConfigure>());

        return services;
    }

    public static void UseFeatures(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var databaseInitializer = new DatabaseInitializer(scope.ServiceProvider);
        databaseInitializer.Execute();

        app.UseRequestLocalization();
        app.UseFastEndpoints(o => _jsonSerializerOptionsSetup(o.Serializer.Options));
        app.UseSwaggerGen();
    }
}
