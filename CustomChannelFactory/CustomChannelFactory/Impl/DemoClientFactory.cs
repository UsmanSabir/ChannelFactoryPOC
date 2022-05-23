using System.Diagnostics;
using CustomChannelFactory.Abstraction;

namespace CustomChannelFactory.Impl;

internal class DemoClientFactory : IClientFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DemoClientFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T CreateClient<T>() where T : IBusinessService
    {
        //var businessServices = _serviceProvider.GetRequiredService<IEnumerable<T>>();
        //var interfaceType = typeof(T);

        //foreach (var service in businessServices)
        //{
        //    var type = service.GetType();
        //    if (interfaceType.IsAssignableFrom(type) && (type.Assembly.FullName?.Contains("ProxyBuilder") ?? false) == false)
        //    {
        //        Debug.WriteLine($"{type.FullName} is concrete implementation");
        //    }
        //}

        var businessService = _serviceProvider.GetRequiredService<T>();
        return businessService;
    }
}