using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;

namespace OrderingSystem.AOProgramming.Sample.AOP;

public class MemoryCacheInterceptor : Castle.DynamicProxy.IInterceptor
{
    private IMemoryCache memoryCache;
    private TimeSpan cacheDuration = TimeSpan.FromSeconds(30);
    public MemoryCacheInterceptor(IMemoryCache memoryCache) => this.memoryCache = memoryCache;
    public void Intercept(IInvocation invocation)
    {
        Type? declaringType = invocation.Method.DeclaringType;
        string? methodName = invocation.Method.Name;
        IEnumerable<string?> arguments = invocation.Arguments.Select(
            arg => (arg ?? string.Empty).ToString());

        string? commaSeparatedArguments = string.Join(", ", arguments);
        string? cacheKey = $"{declaringType}|{methodName}|{commaSeparatedArguments}";

        if(!memoryCache.TryGetValue(cacheKey, out object? returnValue))
        {
            invocation.Proceed();
            returnValue = invocation.ReturnValue;
            memoryCache.Set(cacheKey, returnValue, cacheDuration);
        }
        else
        {
            invocation.ReturnValue = returnValue;
        }
    }
}
