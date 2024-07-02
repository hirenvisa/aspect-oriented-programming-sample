using OrderingSystem.AOProgramming.Sample.Models;

namespace OrderingSystem.AOProgramming.SampleData.Access;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer Get(int Id);
}
