using System;

class SmartInventoryManagement
{
    static void Main()
    {
        string[] productNames = new string[50];
        double[] productPrices = new double[50];
        int[] productStocks = new int[50];
        int productCount = 0;

        while (true)
        {
            Console.WriteLine("\n--- Smart Inventory Management ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number between 1-5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddProduct(productNames, productPrices, productStocks, ref productCount);
                    break;
                case 2:
                    UpdateStock(productNames, productStocks, productCount);
                    break;
                case 3:
                    ViewProducts(productNames, productPrices, productStocks, productCount);
                    break;
                case 4:
                    RemoveProduct(productNames, productPrices, productStocks, ref productCount);
                    break;
                case 5:
                    Console.WriteLine("Exiting system. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Enter 1-5.");
                    break;
            }
        }
    }

    // Method to Add a Product
    static void AddProduct(string[] names, double[] prices, int[] stocks, ref int count)
    {
        Console.Write("Enter Product Name: ");
        string newProduct = Console.ReadLine();

        // Check if product exists
        for (int i = 0; i < count; i++)
        {
            if (names[i].ToLower() == newProduct.ToLower())
            {
                Console.WriteLine("Product already exists in inventory!");
                return;
            }
        }

        names[count] = newProduct;

        // Validate price input
        double price;
        while (true)
        {
            Console.Write("Enter Product Price: ");
            if (double.TryParse(Console.ReadLine(), out price))
                break;
            Console.WriteLine("Invalid input! Enter a valid number.");
        }
        prices[count] = price;

        // Validate stock input
        int stock;
        while (true)
        {
            Console.Write("Enter Stock Quantity: ");
            if (int.TryParse(Console.ReadLine(), out stock))
                break;
            Console.WriteLine("Invalid input! Enter a valid integer.");
        }
        stocks[count] = stock;

        count++;
        Console.WriteLine("Product added successfully!");
    }

    // Method to Update Stock
    static void UpdateStock(string[] names, int[] stocks, int count)
    {
        Console.Write("Enter Product Name to Update Stock: ");
        string name = Console.ReadLine();
        int index = -1;

        for (int i = 0; i < count; i++)
        {
            if (names[i].ToLower() == name.ToLower())
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        int qty;
        while (true)
        {
            Console.Write("Enter quantity to add/remove: ");
            if (int.TryParse(Console.ReadLine(), out qty))
                break;
            Console.WriteLine("Invalid input! Enter a valid integer.");
        }

        if (stocks[index] + qty < 0)
        {
            Console.WriteLine("Error: Stock cannot be negative!");
        }
        else
        {
            stocks[index] += qty;
            Console.WriteLine("Stock updated successfully!");
        }
    }

    // Method to View Products
    static void ViewProducts(string[] names, double[] prices, int[] stocks, int count)
    {
        if (count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        Console.WriteLine("\n--- Product List ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Name: {names[i]}");
            Console.WriteLine($"Price: {prices[i]}");
            Console.WriteLine($"Stock: {stocks[i]}");
            Console.WriteLine("-------------------");
        }
    }

    // Method to Remove a Product
    static void RemoveProduct(string[] names, double[] prices, int[] stocks, ref int count)
    {
        Console.Write("Enter Product Name to Remove: ");
        string name = Console.ReadLine();
        int index = -1;

        for (int i = 0; i < count; i++)
        {
            if (names[i].ToLower() == name.ToLower())
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        // Shift arrays to remove product
        for (int i = index; i < count - 1; i++)
        {
            names[i] = names[i + 1];
            prices[i] = prices[i + 1];
            stocks[i] = stocks[i + 1];
        }

        count--;
        Console.WriteLine("Product removed successfully!");
    }
}