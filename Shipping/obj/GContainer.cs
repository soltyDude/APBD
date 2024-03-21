public class GContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; } // Stored in atmospheres

    public GContainer(double height, double tareWeight, double depth, double maxPayload, string serialNumber, double pressure)
        : base(height, tareWeight, depth, maxPayload, serialNumber)
    {
        Pressure = pressure;
    }

    public override void EmptyCargo()
    {
        CargoMass *= 0.05; // Leave 5% of gas inside the container
        Console.WriteLine($"Gas Container {SerialNumber} emptied, leaving 5% of gas inside.");
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Hazardous situation in Gas Container: {SerialNumber}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Gas Container - Serial: {SerialNumber}, Pressure: {Pressure} atm");
    }
}