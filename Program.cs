using System.Data.Common;

List<ProductType> productTypeList = new List<ProductType>()
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
            throw new NotImplementedException();
            // break;
        
        case 2:
            throw new NotImplementedException();
            // break;

        case 3:
            throw new NotImplementedException();
            // break;

        case 4:
            throw new NotImplementedException();
            // break;

        case 5:
            throw new NotImplementedException();
            // break;

        case 6:
            Console.WriteLine(@"
            Thanks for shopping lookout for the giant bats outside!!!
            ");
            break;

        default:
            throw new FormatException();
    }

}
