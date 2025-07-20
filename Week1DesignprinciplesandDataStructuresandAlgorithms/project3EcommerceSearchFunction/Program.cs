using System;

class Program
{
  
    static Product? LinearSearch(Product[] products, int targetId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == targetId)
                return product;
        }
        return null;
    }

  
    static Product? BinarySearch(Product[] products, int targetId)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (products[mid].ProductId == targetId)
                return products[mid];
            if (products[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }

    static void Main()
    {
        
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(205, "Coffee Maker", "Kitchen"),
            new Product(307, "Yoga Mat", "Fitness"),
            new Product(412, "Desk Lamp", "Furniture")
        };

        Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));

        Console.WriteLine("Searching for Product ID 307 using Linear Search:");
        var result1 = LinearSearch(products, 307);
        Console.WriteLine(result1 != null ? $"Found: {result1.ProductName}" : "Not found");

        Console.WriteLine("\nSearching for Product ID 205 using Binary Search:");
        var result2 = BinarySearch(products, 205);
        Console.WriteLine(result2 != null ? $"Found: {result2.ProductName}" : "Not found");
    }
}
