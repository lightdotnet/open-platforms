using Light.Tiki;

namespace Api.Tiki;

public static class DependencyInjection
{
    public static void AddTiki(this IServiceCollection services)
    {
        services.AddScoped<ITikiCredential, Credentials>();

        services.AddTikiHttpClient();
        services.AddTikiAPI();
    }

    public static void MapTiki(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("tiki");

        group.MapEndpoints();
    }
}
