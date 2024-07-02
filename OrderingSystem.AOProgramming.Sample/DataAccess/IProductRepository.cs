using OrderingSystem.AOProgramming.Sample.Models;

namespace OrderingSystem.AOProgramming.SampleData.Access;

public interface IProductRepository
{
    List<Product> GetAll();
    Product Get(int Id);
    void Create(Product product);
    void Delete(Product product);

}
