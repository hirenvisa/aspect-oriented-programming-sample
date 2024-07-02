using OrderingSystem.AOProgramming.Sample.AOP;
using OrderingSystem.AOProgramming.Sample.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrderingSystem.AOProgramming.SampleData.Access;

namespace OrderingSystem.AOProgramming.Sample.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository, IMemoryCache memoryCache)
    {
        _productRepository = productRepository;
    }

     
    public IActionResult Index()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }
}
