using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
optionsBuilder.UseSqlite("Data Source=northwind.db");

using (var db = new NorthwindContext(optionsBuilder.Options))
{
    while (true) 
    {
        Console.Clear();
        Console.WriteLine("=== Sqlite and Linq exercice ===");
        Console.WriteLine("1. Exercice 1 : Companies name");
        Console.WriteLine("2. Exercice 2 : Client's detail");
        Console.WriteLine("3. Exercice 3 : Clients (by city)");
        Console.WriteLine("4. Exercice 4 : Product informations");
        Console.WriteLine("5. Exercice 5 : add a product");
        Console.WriteLine("6. Exercice 6 : update a product");
        Console.WriteLine("7. Exercice 7 : update multiple product");
        Console.WriteLine("8. Exercice 8 : delete a product");

        Console.WriteLine("Q. exit");
        Console.Write("Your choice : ");

        var choice = Console.ReadLine();

        if (choice == "q" || choice == "Q") break;

        Console.WriteLine("\n--- Result ---\n");

        switch (choice)
        {
            case "1":
                Exercice1(db);
                break;
            case "2":
                Exercice2(db);
                break;
            case "3":
                Exercice3(db);
                break;
            case "4":
                Exercice4(db);
                break;
            case "5":
                Exercice5(db);
                break;
            case "6":
                Exercice6(db);
                break;
            case "7":
                Exercice7(db);
                break;
            case "8":
                Exercice8(db);
                break;
            
            
            default:
                Console.WriteLine("Invalid !");
                break;
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}


// Exercice 1 
static void Exercice1(NorthwindContext db)
{
    var names = db.Customers
                  .Select(c => c.CompanyName)
                  .ToList();

    foreach (var name in names)
    {
        Console.WriteLine(name);
    }
}

//exercice 2
static void Exercice2(NorthwindContext db)
{
    var customers = db.Customers.Take(10).ToList(); 

    foreach (var c in customers)
    {
        Console.WriteLine($"ID: {c.CustomerId} | Sté: {c.CompanyName} | Contact: {c.ContactName}");
    }
}

// Exercice 3 
static void Exercice3(NorthwindContext db)
{
    Console.Write("wich city ? (ex: London) : ");
    var ville = Console.ReadLine();

    var customers = db.Customers
                      .Where(c => c.City == ville)
                      .Select(c => c.CompanyName)
                      .Distinct() 
                      .ToList();

    if (customers.Count == 0) Console.WriteLine("No client found.");

    foreach (var c in customers)
    {
        Console.WriteLine($" -> {c}");
    }
}

static void Exercice4(NorthwindContext db)
{
    Console.WriteLine("--- Product ---");

    var query = db.Products
                  .Include(p => p.Category) 
                  .Select(p => new { 
                      CatName = p.Category.CategoryName, 
                      ProdName = p.ProductName 
                  })
                  .OrderBy(x => x.CatName);

    foreach (var item in query)
    {
        Console.WriteLine($"{item.CatName} : {item.ProdName}");
    }
}

// Exercice 5 
static void Exercice5(NorthwindContext db)
{
    
    var newProduct = new Product
    {
        ProductName = "Kickapoo Juice", 
        UnitPrice = 15,
        Discontinued = "" 
    };

    db.Products.Add(newProduct);
    db.SaveChanges(); 

    Console.WriteLine($"Prodcut added, id : {newProduct.ProductId}");
}


static void Exercice6(NorthwindContext db)
{
    Console.WriteLine("Editing");

    var product = db.Products.FirstOrDefault(p => p.ProductName.StartsWith("Kickapoo"));

    if (product != null)
    {
        Console.WriteLine($"old price : {product.UnitPrice}");
        
        
        product.UnitPrice = 100; 

        db.SaveChanges();
        Console.WriteLine("new price saved : 100");
    }
    else
    {
        Console.WriteLine("No product found, add some with exercice5()");
    }
}


static void Exercice7(NorthwindContext db)
{
    Console.WriteLine("adding");

    var products = db.Products.Where(p => p.UnitPrice > 20).ToList();

    foreach (var p in products)
    {
        p.UnitPrice += 1; 
    }

    db.SaveChanges();
    Console.WriteLine($"{products.Count} product updated.");
}

// Exercice 8 
static void Exercice8(NorthwindContext db)
{
    var productsToDelete = db.Products
                             .Where(p => p.ProductName.StartsWith("Kick"))
                             .ToList();

    if (productsToDelete.Count == 0)
    {
        Console.WriteLine("nothing to delete.");
        return;
    }

    db.Products.RemoveRange(productsToDelete);
    db.SaveChanges();

    Console.WriteLine($"{productsToDelete.Count} product(s) deleted).");
}