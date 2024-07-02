using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using OrderingSystem.AOProgramming.Sample.AOP;
using OrderingSystem.AOProgramming.SampleData.Access;

namespace OrderingSystem.AOProgramming.Sample;

public static class ContainerHelper
{
    public static WebApplication BuildContainer(WebApplicationBuilder builder)
    {
        builder.Host.UseServiceProviderFactory(
            new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterType<MemoryCacheInterceptor>();
                builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerDependency()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MemoryCacheInterceptor));

                builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerDependency()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MemoryCacheInterceptor)); 
            });

        return builder.Build();
    }
}
