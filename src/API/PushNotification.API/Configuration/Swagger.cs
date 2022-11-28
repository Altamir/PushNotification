using FastEndpoints.ClientGen;
using FastEndpoints.Swagger;

namespace PushNotification.API.Configuration;

public static class Swagger
{
    public static void AddSwaggerDocWithConfig(this IServiceCollection services)
    {
        const string apiDefaultTitle = "Push Notification";
        services
            .AddSwaggerDoc(maxEndpointVersion: 1, settings: s =>
            {
                s.DocumentName = "Release 1.0";
                s.Title = apiDefaultTitle;
                s.Version = "v1.0";
            })
            .AddSwaggerDoc(maxEndpointVersion: 2, settings: s =>
            {
                s.DocumentName = "Release 2.0";
                s.Title = apiDefaultTitle;
                s.Version = "v2.0";
            });
    }

    public static void AddClientGenerator(this WebApplication app)
    {
        app.MapCSharpClientEndpoint("/cs-client", "Release 2.0", s =>
        {
            s.ClassName = "ApiClient";
            s.CSharpGeneratorSettings.Namespace = "ServicePushNotification";
        });

        app.MapTypeScriptClientEndpoint("/ts-client", "Release 2.0", s =>
        {
            s.ClassName = "ApiClient";
            s.TypeScriptGeneratorSettings.Namespace = "ServicePushNotification";
        });
    }
}