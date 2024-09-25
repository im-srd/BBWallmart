using System;
using System.Collections.Generic;

namespace BBWallmart.MB
{
    class MainBranch
    {
        public Dictionary<string, int> ItemList { get; set; } = new Dictionary<string, int>(); // item_name : stock_left
        public List<string> SuppliersList { get; set; } = new List<string>(); // names_of_supplier

        public void BranchDetails()
        {
            foreach (var entry in ItemList)
            {
                Console.WriteLine("Item Name: " + entry.Key);
                Console.WriteLine("Stock: " + entry.Value);
                Console.WriteLine();
            }
        }
    }
}
