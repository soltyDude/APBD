public class CContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    public CContainer(double height, double tareWeight, double depth, double maxPayload, string serialNumber, string productType, double temperature)
        : base(height, tareWeight, depth, maxPayload, serialNumber)
    {
        ProductType = productType;
        Temperature = temperature;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Refrigerated Container - Serial: {SerialNumber}, Product: {ProductType}, Temp: {Temperature}°C");
    }
}