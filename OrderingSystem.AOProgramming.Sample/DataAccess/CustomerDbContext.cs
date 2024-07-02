using OrderingSystem.AOProgramming.Sample.Models;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace OrderingSystem.AOProgramming.Sample.DataAccess;

public class CustomerDbContext : DbContext
{

    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseInMemoryDatabase(databaseName: "OrderManagementSystem");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var data = GenerateCustomerData();
        modelBuilder.Entity<Customer>().HasData(data);
    }

    public DbSet<Customer> Customers { get; set; }


    private Customer[] GenerateCustomerData()
    {
        var customerFaker = new Faker<Customer>()
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.Address, f => f.Address.FullAddress())
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
            .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber());

        return customerFaker.Generate(count: 10).ToArray();
    }
}
