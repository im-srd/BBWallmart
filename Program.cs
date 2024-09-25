using System;
using BBWallmart.MB;
using BBWallmart.S;
using BBWallmart.O;

namespace BBWallmart.Main
{
    class MainMethod
    {
        public static void Main(string[] args)
        {
            // MAIN BRANCH
            // ----------------------------------------------------------------
            MainBranch mainBranch = new MainBranch();

            // SUPPLIERS
            // ----------------------------------------------------------------
            Console.WriteLine("How many Suppliers do you want to add?");
            int noOfSup = int.Parse(Console.ReadLine());
            Suppliers[] suppliers = new Suppliers[noOfSup];

            for (int i = 0; i < noOfSup; i++)
            {
                Suppliers supplier = new Suppliers();
                suppliers[i] = supplier.AddSupplier();
                Console.WriteLine("Enter the Item Name:");
                string item_name = Console.ReadLine();
                suppliers[i].ItemName = item_name;
                Console.WriteLine("Enter the stocks");
                int stocks = int.Parse(Console.ReadLine());
                suppliers[i].Stock = stocks;
            }

            // OUTLETS
            // ----------------------------------------------------------------
            Console.WriteLine("How many Outlets do you have?");
            int noOfOutlets = int.Parse(Console.ReadLine());
            Outlets[] outlets = new Outlets[noOfOutlets];

            for (int i = 0; i < noOfOutlets; i++)
            {
                Outlets outlet = new Outlets();
                outlets[i] = outlet.AddOutlets();
            }

            // Main loop
            while (true)
            {
                Console.WriteLine("\n*** BHAI BHAI WALLMART ***\n");
                Console.WriteLine("1. Suppliers detail\n2. Main Branch details\n3. Add Items in Outlets\n4. Add Items in MainBranch\n5. Exit");
                int ch1 = int.Parse(Console.ReadLine());
                switch (ch1)
                {
                    case 1:
                        foreach (var supplier in suppliers)
                        {
                            supplier.SupplierDetails();
                        }
                        break;

                    case 2:
                        mainBranch.BranchDetails();
                        break;

                    case 3:
                        for (int i = 0; i < noOfOutlets; i++)
                        {
                            Console.WriteLine($"Outlet {i + 1}: {outlets[i].OutletName} --- Press {i + 1}");
                        }

                        Console.WriteLine("Enter your choice:");
                        int ch2 = int.Parse(Console.ReadLine());
                        if (ch2 >= 1 && ch2 <= noOfOutlets)
                        {
                            mainBranch.BranchDetails();

                            Console.WriteLine("Enter the name of the item:");
                            string itemToBuy = Console.ReadLine();
                            if (mainBranch.ItemList.ContainsKey(itemToBuy))
                            {
                                Console.WriteLine("How many stocks?");
                                int stockToBuy = int.Parse(Console.ReadLine());
                                if (mainBranch.ItemList[itemToBuy] > 0)
                                {
                                    mainBranch.ItemList[itemToBuy] -= stockToBuy;
                                    outlets[ch2 - 1].ItemName = itemToBuy;
                                    outlets[ch2 - 1].Stock += stockToBuy;
                                    Console.WriteLine($"{itemToBuy} bought --- {stockToBuy} stocks.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Not enough stock in Main Branch.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Item not found in Main Branch.");
                            }
                        }
                        break;

                    case 4:
                        for (int i = 0; i < noOfSup; i++)
                        {
                            suppliers[i].SupplierDetails();
                            Console.WriteLine("Do you want to buy " + suppliers[i].ItemName+"? (Type '" + suppliers[i].ItemName);
                            string itemToBuy = Console.ReadLine();
                            if (suppliers[i].ItemName == itemToBuy)
                            {
                                Console.WriteLine("How many stocks?");
                                int stockToBuy = int.Parse(Console.ReadLine());
                                if (suppliers[i].Stock >= stockToBuy)
                                {
                                    suppliers[i].Stock -= stockToBuy;
                                    if (mainBranch.ItemList.ContainsKey(itemToBuy))
                                        mainBranch.ItemList[itemToBuy] += stockToBuy;
                                    else
                                        mainBranch.ItemList[itemToBuy] = stockToBuy;
                                    Console.WriteLine($"{itemToBuy} added to Main Branch --- {stockToBuy} stocks.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Not enough stock with supplier.");
                                }
                            }
                        }
                        break;

                    case 5:
                        return;
                }
            }
        }
    }
}
