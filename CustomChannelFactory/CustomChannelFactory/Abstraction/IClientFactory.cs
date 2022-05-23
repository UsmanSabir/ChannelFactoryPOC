namespace CustomChannelFactory.Abstraction;

public interface IClientFactory
{
    T CreateClient<T>() where T : IBusinessService;

}