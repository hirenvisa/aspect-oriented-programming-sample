using OrderingSystem.AOProgramming.Sample.Models;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.AOProgramming.Sample.DataAccess;

namespace OrderingSystem.AOProgramming.SampleData.Access;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public CustomerRepository()
    {
        var options = new DbContextOptionsBuilder<CustomerDbContext>()
            .UseInMemoryDatabase("OrderManagementSystem").Options;
        _context = new CustomerDbContext(options);
        _context.Database.EnsureCreated();

    }
    public Customer Get(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAll() => _context.Customers.ToList();
}
