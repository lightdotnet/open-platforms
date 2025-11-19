using Light.Shopee;
using Light.Shopee.Models.Order;
using Light.Shopee.Models.Returns;
using Microsoft.AspNetCore.Mvc;

namespace Api.Shopee;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint
            .MapGet("/orders", (IOrderClient orderClient) =>
            {
                var request = new GetOrderListRequest(DateTime.Today, DateTime.Now);

                return orderClient.GetOrderList(request);
            });

        endpoint
            .MapGet("/order/{ordersn}", ([FromRoute] string ordersn, IOrderClient orderClient) =>
            {
                return orderClient.GetOrderDetails([ordersn]);
            });

        endpoint
            .MapGet("/order/get_pending_buyer_invoice_list", (IOrderClient orderClient) =>
            {
                return orderClient.GetPendingBuyerInvoiceOrderList();
            });

        endpoint
            .MapPost("/order/get_buyer_invoice_info", ([FromBody] string[] orders, IOrderClient orderClient) =>
            {
                return orderClient.GetBuyerInvoiceInfo(orders);
            });
    }

    public static void MapReturnEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint
            .MapGet("/returns", (IReturnsClient client) =>
            {
                var request = new GetReturnListRequest();
                request.ByCreateTime(DateTime.Now.AddDays(-15), DateTime.Now);

                return client.GetReturnList(request);
            });

        endpoint
            .MapGet("/return/{returnsn}", ([FromRoute] string returnsn, IReturnsClient orderClient) =>
            {
                return orderClient.GetReturnDetail(returnsn);
            });
    }

    public static void MapPaymentEndpoints(this IEndpointRouteBuilder endpoint)
    {
        endpoint
            .MapGet("/payment/{ordersn}/", ([FromRoute] string ordersn, IPaymentClient client) =>
            {
                return client.GetEscrowDetail(ordersn);
            });
    }
}
