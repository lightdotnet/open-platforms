using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Light.Shopee.Models.Order
{
    public class PendingBuyerInvoiceOrderResponse
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
