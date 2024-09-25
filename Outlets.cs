using System;

namespace BBWallmart.O
{
    class Outlets
    {
        public string OutletName { get; set; }
        public string ItemName { get; set; }
        public int Stock { get; set; } = 0;

        public Outlets AddOutlets()
        {
            Outlets outlet = new Outlets();
            Console.WriteLine("Enter the Outlet Name:");
            outlet.OutletName = Console.ReadLine();
            return outlet;
        }

        public void OutletDetails()
        {
            Console.WriteLine("Outlet Name: " + this.OutletName);
            Console.WriteLine("Item Name: " + this.ItemName);
            Console.WriteLine("Stock Left: " + this.Stock);
        }
    }
}
