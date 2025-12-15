namespace Light.Grab.GrabExpress.Common
{
    public class Courier
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string pictureURL { get; set; }
        public int rating { get; set; }
        public Coordinates coordinates { get; set; }
        public Vehicle vehicle { get; set; }
        public object extraInfo { get; set; }
    }

    public class Vehicle
    {
        public string licensePlate { get; set; }
        public string model { get; set; }
        public string vehicleType { get; set; }
    }
}
