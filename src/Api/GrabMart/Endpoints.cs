using Light.Grab.GrabMart;
using Microsoft.AspNetCore.Mvc;

namespace Api.GrabMart;

public static class Endpoints
{
    public static void MapGrabMartEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint
            .MapGet("/{merchandId}/orders/", ([FromRoute] string merchandId, IOrderClient orderClient) =>
            {
                return orderClient.GetOrderList(merchandId, DateTime.Today, 1);
            });

        endpoint
            .MapGet("/order/update", (IOrderClient orderClient) =>
            {
                return orderClient.Update(new()
                {
                    OrderID = "test_id"
                });
            });

        endpoint
            .MapGet("/store-active/{partnerMerchantId}", (
                [FromRoute] string partnerMerchantId,
                ISelfServeActivation client) =>
            {
                return client.GetActivationUrl(partnerMerchantId);
            });
    }
}
