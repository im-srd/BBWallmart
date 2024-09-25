using System;

namespace BBWallmart.S
{
    class Suppliers
    {
        public string SupplierName { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int Stock { get; set; }

        public Suppliers AddSupplier()
        {
            Suppliers supplier = new Suppliers();
            Console.WriteLine("Enter the Supplier Name:");
            supplier.SupplierName = Console.ReadLine();
            return supplier;
        }

        public void SupplierDetails()
        {
            Console.WriteLine("Supplier Name: " + this.SupplierName);
            Console.WriteLine("Item Name: " + this.ItemName + "\t(" + this.ItemPrice + ")");
            Console.WriteLine("Stock Left: " + this.Stock);
        }
    }
}
