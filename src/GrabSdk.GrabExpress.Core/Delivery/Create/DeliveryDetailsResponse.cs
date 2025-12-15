using Light.Grab.GrabExpress.Common;
using System;
using System.Collections.Generic;

namespace Light.Grab.GrabExpress.Delivery.Create
{
    public class DeliveryDetailsResponse
    {
        public string deliveryID { get; set; }
        public string merchantOrderID { get; set; }
        public string paymentMethod { get; set; }
        public Quote quote { get; set; }
        public ContactInfo sender { get; set; }
        public ContactInfo recipient { get; set; }
        public string status { get; set; }
        public string trackingURL { get; set; }
        public Courier courier { get; set; }
        public Timeline timeline { get; set; }
        public Schedule schedule { get; set; }
        public CashOnDelivery cashOnDelivery { get; set; }
        public string invoiceNo { get; set; }
        public string pickupPin { get; set; }
        public AdvanceInfo advanceInfo { get; set; }
    }

    public class Quote
    {
        public Service service { get; set; }
        public Currency currency { get; set; }
        public double amount { get; set; }
        public EstimatedTimeline estimatedTimeline { get; set; }
        public double distance { get; set; }
        public Location origin { get; set; }
        public Location destination { get; set; }
        public List<Package> packages { get; set; }
    }

    public class Timeline
    {
        public DateTime create { get; set; }
        public DateTime allocate { get; set; }
        public DateTime pickup { get; set; }
        public DateTime dropoff { get; set; }
        public DateTime completed { get; set; }
    }

    public class AdvanceInfo
    {
        public string failedReason { get; set; }
    }
}
