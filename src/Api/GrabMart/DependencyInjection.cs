using Light.Grab.Auth;
using Light.Grab.GrabMart;

namespace Api.GrabMart;

public static class DependencyInjection
{
    public static void AddGrabMart(this IServiceCollection services)
    {
        services.AddScoped<IGrabMartCredential, Credentials>();

        services.AddGrabAuthHttpClient("");
        services.AddGrabMartHttpClient();
        services.AddGrabMartAPI();
    }

    public static void MapGrabMart(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("grabmart");

        group.MapGrabMartEndpoints();
    }
}
