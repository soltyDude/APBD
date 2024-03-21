public class Ship
{
    public List<Container> Containers { get; set; } = new List<Container>();
    public int MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxCargoWeight { get; }
    public string Name { get; }

    public Ship(string name, int maxSpeed, int maxContainers, double maxCargoWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxCargoWeight = maxCargoWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers || Containers.Sum(c => c.CargoMass) + container.CargoMass > MaxCargoWeight)
        {
            Console.WriteLine("Cannot load container: Ship capacity exceeded.");
            return;
        }
        Containers.Add(container);
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
        }
        else
        {
            Console.WriteLine("Container not found.");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship: {Name}, Max Speed: {MaxSpeed} knots, Max Containers: {MaxContainers}, Max Cargo Weight: {MaxCargoWeight} tons");
        Console.WriteLine("Containers on board:");
        foreach (var container in Containers)
        {
            container.PrintInfo();
        }
    }
}