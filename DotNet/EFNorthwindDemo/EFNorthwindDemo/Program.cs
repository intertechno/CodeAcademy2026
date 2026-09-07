using EFNorthwindDemo.Entities;

using NorthwindContext ctx = new();

// query the Finnish customers from the Customers table
List<Customer> finnishCustomers = [.. ctx.Customers.Where(
    c => c.Country == "Finland")];

foreach (Customer customer in finnishCustomers)
{
    Console.WriteLine(customer.CompanyName);
}
