using CustomChannelFactory.Abstraction;

namespace CustomChannelFactory.DomainServices;

public interface IContractService : IBusinessService
{
    int Sum(int a, int b);
}