using Light.Shopee;

namespace Api.Shopee;

public static class DependencyInjection
{
    public static void AddShopee(this IServiceCollection services)
    {
        services.AddScoped<IShopeeCredential, Credentials>();

        services.AddShopeeHttpClient();
        services.AddShopeeAPIv2();
    }

    public static void MapShopee(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("shopee");

        group.MapProductEndpoints();
        group.MapOrderEndpoints();
        group.MapPaymentEndpoints();
        group.MapReturnEndpoints();
        group.MapLogisticsEndpoints();
        group.MapPublicEndpoints();
    }
}
