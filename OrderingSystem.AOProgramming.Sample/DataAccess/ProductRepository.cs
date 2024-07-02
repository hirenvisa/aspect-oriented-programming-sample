using OrderingSystem.AOProgramming.Sample.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderingSystem.AOProgramming.SampleData.Access;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductRepository()
    {
        var options = new DbContextOptionsBuilder<ProductDbContext>()
            .UseInMemoryDatabase("OrderManagementSystem").Options;
        _dbContext = new ProductDbContext(options);
        _dbContext.Database.EnsureCreated();
    }
    public void Create(Product product)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product product)
    {
        throw new NotImplementedException();
    }

    public Product Get(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll() => _dbContext.Products.ToList();
}
