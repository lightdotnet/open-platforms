using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Light.Shopee.Models.Order
{
    public class PendingBuyerInvoiceOrderResult
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public PendingBuyerInvoiceOrderData Data { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("user_message")]
        public string UserMessage { get; set; }
    }

    public class PendingBuyerInvoiceOrderData
    {
        [JsonPropertyName("more")]
        public bool More { get; set; }

        [JsonPropertyName("next_cursor")]
        public string NextCursor { get; set; }

        [JsonPropertyName("order_list")]
        public List<PendingBuyerInvoiceOrderDto> OrderList { get; set; }
    }

    public class PendingBuyerInvoiceOrderDto
    {
        [JsonPropertyName("order_sn")]
        public string OrderSn { get; set; }
    }
}
