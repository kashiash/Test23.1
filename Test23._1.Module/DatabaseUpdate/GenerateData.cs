using Bogus;
using DevExpress.ExpressApp;
using Test23._1.Module.BusinessObjects;

public static class DataGenerator
{
    public static void GenerateData(IObjectSpace objectSpace)
    {


        string[] productNames = { "Hamburger", "Pizza", "Tacos", "Sushi", "Fried chicken", "Spaghetti", "Burrito", "Steak", "Salmon", "Pad Thai" };
        string[] categories = { "Fast food", "Italian", "Mexican", "Japanese", "Fried chicken", "Italian", "Mexican", "Steakhouse", "Seafood", "Thai" };
        string[] descriptions = { "Double decker hamburger with cheese", "Thin crust pizza with pepperoni", "Soft shell tacos with beef", "Assorted sushi rolls with wasabi", "Crispy fried chicken with hot sauce", "Spaghetti with meatballs and marinara sauce", "Bean and cheese burrito with guacamole", "Juicy sirloin steak with baked potato", "Grilled salmon with lemon butter sauce", "Spicy pad Thai noodles with shrimp" };


        var customerFaker = new Faker<Customer>()
             .CustomInstantiator(f => objectSpace.CreateObject<Customer>())
            .RuleFor(c => c.Name, f => f.Company.CompanyName())
            .RuleFor(c => c.VATID, f => f.Random.Replace("####-###-####-###-##"))
            .RuleFor(c => c.Notes, f => f.Rant.Review())
        .RuleFor(c=> c.Description, f => f.PickRandom(descriptions))
            .RuleFor(c=> c.Category, f => f.PickRandom(categories));
        customerFaker.Generate(100);
        var customers = objectSpace.GetObjectsQuery<Customer>(true).ToList();

        var addressFaker = new Faker<Address>()
             .CustomInstantiator(f => objectSpace.CreateObject<Address>())
            .RuleFor(a => a.Line1, f => f.Address.StreetAddress())
            .RuleFor(a => a.Line2, f => f.Address.SecondaryAddress())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.State, f => f.Address.StateAbbr())
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode())
         .RuleFor(o => o.Customer, f => f.PickRandom(customers));
        addressFaker.Generate(100);


        objectSpace.CommitChanges();
        
    }
}