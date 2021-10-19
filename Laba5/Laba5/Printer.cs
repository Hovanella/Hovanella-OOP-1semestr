using System;

namespace Laba5
{
    public class Printer
    {
        public void IAmPrinting(Inventory item)
        {
            Console.WriteLine( item.ToString() );
          
        }
    }
}