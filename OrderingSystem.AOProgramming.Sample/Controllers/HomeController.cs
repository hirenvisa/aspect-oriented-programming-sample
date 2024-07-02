using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrderingSystem.AOProgramming.SampleData.Access;

namespace OrderingSystem.AOProgramming.Sample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerRepository _customerRepository;

    public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository,
        IMemoryCache memoryCache)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public IActionResult Index()
    {
        var Customers = _customerRepository.GetAll();
        return View(Customers);
    }

}
