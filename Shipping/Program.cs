using Shipping.obj;

namespace Shipping;

class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        LContainer lContainer = new LContainer(1.0, 1.0, 1.0, 1.0, 1.0, ref counter);
        LContainer lContainer1 = new LContainer(1.0, 1.0, 1.0, 1.0, 1.0, ref counter);
        LContainer lContainer2 = new LContainer(1.0, 1.0, 1.0, 1.0, 1.0, ref counter);
       
    }
}