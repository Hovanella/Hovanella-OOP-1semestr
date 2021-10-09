using System;

namespace Laba7
{
    public class Printer
    {
        public void IAmPrinting(Inventory item)
        {
            Console.WriteLine(item.ToString());
        }
    }
}