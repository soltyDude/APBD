class Program
{
    static void Main(string[] args)
    {
        var ship = new Ship("SS Great", 20, 100, 20000);

        var refrigeratedContainer = new CContainer(2.5, 500, 2, 1000, "KON-C-1", "Bananas", -5);
        var liquidContainer = new LContainer(2.5, 500, 2, 1000, "KON-L-1", false);
        var gasContainer = new GContainer(2.5, 500, 2, 1000, "KON-G-1", 1.5);

        ship.LoadContainer(refrigeratedContainer);
        ship.LoadContainer(liquidContainer);
        ship.LoadContainer(gasContainer);
        
        ship.UnloadContainer("KON-C-1");

        ship.PrintShipInfo();
    }
}
//