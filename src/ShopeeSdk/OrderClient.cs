using Light.Shopee.Models;
using Light.Shopee.Models.Order;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Light.Shopee
{
    internal class OrderClient : ShopeeHttpClient, IOrderClient
    {
        public OrderClient(IHttpClientFactory httpClientFactory, IShopeeCredential parameters) : base(httpClientFactory, parameters)
        {
        }

        /// inherit docs
        public Task<IShopeeResult<OrderListResponse>> GetOrderList(GetOrderListRequest request) =>
            TryGetAsync<OrderListResponse>("/api/v2/order/get_order_list", request);

        /// inherit docs
        public Task<IShopeeResult<OrdersDetailsResponse>> GetOrderDetails(string[] order_sn_list) =>
            TryGetAsync<OrdersDetailsResponse>("/api/v2/order/get_order_detail",
                new GetOrderDetailsRequest(order_sn_list));

        /// inherit docs
        public Task<string> GetOrderSignedUrl(string ordersn) =>
            BuildSignedUrl("/api/v2/order/get_order_detail",
                new GetOrderDetailsRequest(new string[] { ordersn }));

        public Task<IShopeeResult<HandleBuyerCancellationResponse>> HandleBuyerCancellation(string ordersn, bool accept)
        {
            var path = "/api/v2/order/handle_buyer_cancellation";

            string handle = accept ? "ACCEPT" : "REJECT";

            var request = new
            {
                order_sn = ordersn,
                operation = handle
            };

            return TryPostAsync<HandleBuyerCancellationResponse>(path, request);
        }

        public async Task<PendingBuyerInvoiceOrderResult> GetPendingBuyerInvoiceOrderList(string cursor = "", int page_size = 100)
        {
            var path = "/api/v2/order/get_pending_buyer_invoice_order_list";

            var request = BaseRequest.Create(() => cursor);
            request.Add("page_size", page_size);

            var response = await GetAsync(path, request);

            return await response.Content.ReadFromJsonAsync<PendingBuyerInvoiceOrderResult>();
        }

        public async Task<IShopeeResult<List<BuyerInvoiceInfo>>> GetBuyerInvoiceInfo(string[] orderList)
        {
            var path = "/api/v2/order/get_buyer_invoice_info";

            var request = new
            {
                queries = orderList.Select(s => new
                {
                    order_sn = s
                })
            };

            var response = await PostAsJsonAsync(path, request);

            var result = await response.Content.ReadFromJsonAsync<BuyerInvoiceInfoResponse>();

            return result;
        }
    }
}