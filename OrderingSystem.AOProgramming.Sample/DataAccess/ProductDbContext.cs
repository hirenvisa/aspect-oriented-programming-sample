using OrderingSystem.AOProgramming.Sample.Models;
using Microsoft.EntityFrameworkCore;
using Bogus;
using Bogus.DataSets;

namespace OrderingSystem.AOProgramming.SampleData.Access;

public class ProductDbContext : DbContext
{

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var data = GenerateProductData();
        modelBuilder.Entity<Product>().HasData(data);
    }

    public DbSet<Product> Products { get; set; }


    private Product[] GenerateProductData()
    {
        var productId = 1;
        var productFaker = new Faker<Product>()
            .RuleFor(e => e.Id, f => productId++)
            .RuleFor(e => e.Name, f => f.Commerce.ProductName())
            .RuleFor(e => e.Description, f => f.Commerce.ProductDescription())
            .RuleFor(e => e.Price, f => Math.Round(f.Random.Decimal(1000, 5000), 2));

        return productFaker.Generate(count: 10).ToArray();
    }
}
