using CustomChannelFactory.Abstraction;

namespace CustomChannelFactory.Impl;

public class DemoClientFactory : IClientFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DemoClientFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T CreateClient<T>() where T : IBusinessService
    {
        var businessService = ProxyDecorator<T>.Decorate(_serviceProvider);
        return businessService;
    }
}