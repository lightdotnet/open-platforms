using Light.Shopee.Models;
using Light.Shopee.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Light.Shopee
{
    public interface IOrderClient
    {
        // https://open.shopee.com/documents/v2/v2.order.get_order_list?module=94&type=1
        Task<IShopeeResult<OrderListResponse>> GetOrderList(GetOrderListRequest request);

        // https://open.shopee.com/documents/v2/v2.order.get_order_detail?module=94&type=1
        Task<IShopeeResult<OrdersDetailsResponse>> GetOrderDetails(string[] order_sn_list);
        Task<string> GetOrderSignedUrl(string ordersn);

        // https://open.shopee.com/documents/v2/v2.order.handle_buyer_cancellation?module=94&type=1
        Task<IShopeeResult<HandleBuyerCancellationResponse>> HandleBuyerCancellation(string ordersn, bool accept);

        // https://open.shopee.com/documents/v2/v2.product.get_category?module=89&type=1
        Task<IShopeeResult<PendingBuyerInvoiceOrderResponse>> GetPendingBuyerInvoiceOrderList(string cursor = "", int page_size = 100);

        // https://open.shopee.com/documents/v2/v2.order.get_buyer_invoice_info?module=94&type=1
        Task<IShopeeResult<List<BuyerInvoiceInfo>>> GetBuyerInvoiceInfo(string[] ordersn);
    }
}