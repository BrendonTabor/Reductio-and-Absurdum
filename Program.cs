using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Category = "Apparel"
    },

    new ProductType()
    {
        Category = "Potion"
    },

    new ProductType()
    {
        Category = "Enchanted Object"
    },

    new ProductType()
    {
        Category = "Wand"
    }

};

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Gooseberry Juice",
        Price = 8M,
        Available = true,
        ProductTypeId = 2,
    },

    new Product()
    {
        Name = "Neville's Formal Slippers",
        Price = 12M,
        Available = true,
        ProductTypeId = 1,
    },

    new Product()
    {
        Name = "JSON Object 404",
        Price = 8M,
        Available = false,
        ProductTypeId = 3,
    },

    new Product()
    {
        Name = "The Middle Finger",
        Price = 90M,
        Available = true,
        ProductTypeId = 4,
    }
};

Console.WriteLine(@"Welcome to Red and Abe's magic shop.
~ Specials only during the full moon! ~
Buy your shit and get out!");

void ListProducts(List<Product> prods)
{
    Console.WriteLine("----------------------------------------------");
    for (int i = 0; i < prods.Count; i++ )
    {
        Console.WriteLine($"{i + 1}. {prods[i].Name} is available for {prods[i].Price} golbin coins");
    }
    Console.WriteLine("----------------------------------------------");
}


void ListProductTypes()
{
    for (int i = 0; i < productTypes.Count; i++ )
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Category}");
    }
}

void AddProduct()
{
    Console.WriteLine(@"
    Name your product:");
    string name = Console.ReadLine();

    Console.WriteLine(@"
    how much does the product const");
    decimal Price = decimal.Parse(Console.ReadLine());

    bool Available = true;

    Console.WriteLine(@$"Select a category");

    ListProductTypes();
    
    int ProductTypeId = int.Parse(Console.ReadLine());

    Product productToAdd = new Product()
    {
        Name = name,
        Price = Price,
        Available = true,
        ProductTypeId = ProductTypeId
    };

    products.Add(productToAdd);

    if (products.Last().Name == name)
    {
        Console.WriteLine(@$"{name} was added to the inventory!");
    } else {
        Console.WriteLine(@"There was a problem adding your product to inventory, do better");
    }

    Console.WriteLine(@"Would you like to add another product? y/n.");
    
    string rerun = Console.ReadLine();

    if (rerun == "y")
    {
        AddProduct(); // recursion
    }
     else 
    {

    }

}

void UpdateProduct()
{
    Console.WriteLine(@"Select a product to update");

    ListProducts(products);

    int choice = int.Parse(Console.ReadLine());

    if(choice > 0 || choice <= products.Count)
    {
        Product prod = products[choice -1];
        UpdateProperties(prod);

    }
    else 
    {
        Console.WriteLine(@"Please make a selection from the given options");
    }
}

void DeleteProduct()
{
    Console.WriteLine("Which product would you like to delete");

    ListProducts(products);

    int choice = int.Parse(Console.ReadLine());

    products.RemoveAt(choice -1);

    Console.WriteLine("Product has been deleted!");
}

void ListByProductType()
{
    Console.WriteLine(@"Select a product filter:");
    ListProductTypes();
    int choice = int.Parse(Console.ReadLine());
    List<Product> filteredList= new List<Product>();
    filteredList = products.Where(p => p.ProductTypeId == choice).ToList();
    ListProducts(filteredList);

}

void UpdateProperties(Product prod)
{
    int choice = 0;

    while(choice != 5)
    {
        Console.WriteLine(@$"
        Which property would you like change
        1. Name: {prod.Name}
        2. Price: {prod.Price}
        3. ProductTypeId: {prod.ProductTypeId}
        4. Available: {prod.Available}
        5. I'm finished updating properties
        ");

        choice = int.Parse(Console.ReadLine());

        switch(choice)
        {
            case 1:
                Console.WriteLine("What is the new name of product");
                string name = Console.ReadLine();
                prod.Name = name;
                break;

            case 2:
                Console.WriteLine("What is the new price of the product?");
                string price = Console.ReadLine();
                prod.Price = Decimal.Parse(price);
                break;

            case 3:
                Console.WriteLine("What is the new Product type?");
                ListProductTypes();
                int productType = int.Parse(Console.ReadLine());
                prod.ProductTypeId = productType;
                break;

            case 4:
                prod.Available = !prod.Available;
                Console.WriteLine(prod.Available
                    ?   $"Your product is now stock" 
                    :   "Your product has been sold out!");
                break;
            
            case 5:
                Console.WriteLine("Product update completed");
                break;

            default:
                Console.WriteLine("Please choose from he listed options only");
                break;
        }
    }
}


int choice = 0;

while(choice != 6)
{
Console.WriteLine(@"

    Please select an option:

    1. Display all products.
    2. Display by product type.
    3. Add a product.
    4. Update a product.
    5. Delete a product.
    6. Exit 

    ");

    choice = int.Parse(Console.ReadLine());

    switch(choice)
    {
        case 1:
            ListProducts(products);
            break;
        
        case 2:
            ListByProductType();
            break;

        case 3:
            AddProduct();
            break;

        case 4:
            UpdateProduct();
            break;

        case 5:
            DeleteProduct();
            break;

        case 6:
            Console.WriteLine(@"
            Thanks for shopping lookout for the giant bats outside!!!
            ");
            break;

        default:
            throw new FormatException();
    }

}
