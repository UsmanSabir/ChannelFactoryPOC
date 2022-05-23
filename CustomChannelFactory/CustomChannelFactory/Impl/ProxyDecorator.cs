using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using CustomChannelFactory.Abstraction;

namespace CustomChannelFactory.Impl;

internal class ProxyDecorator<T> : DispatchProxy where T : IBusinessService
{
    //public T Target { get; private set; } //todo

    private string _serviceId;

    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        try
        {
            //todo
            //var result = targetMethod.Invoke(Target, args);
            //return result;

            //route to _serviceId url

            var json = JsonSerializer.Serialize(args);
            Debug.WriteLine(json);
            var objects = JsonSerializer.Deserialize<object?[]>(json);
            Debug.WriteLine(objects[0]);
            return 5;
        }
        catch (TargetInvocationException exc)
        {
            // If the MethodInvoke.Invoke call fails, log a warning and then rethrow the exception
            //_logger.Warning(exc.InnerException, "Method {TypeName}.{MethodName} threw exception: {Exception}", targetMethod.DeclaringType.Name, targetMethod.Name, exc.InnerException);

            throw exc.InnerException;
        }
    }


    public static T Decorate(IServiceProvider serviceProvider, string serviceId, T? target = default)
    {
        var proxy = Create<T, ProxyDecorator<T>>();
            //as ProxyDecorator<T>;

            var proxyDecorator = (proxy as ProxyDecorator<T>);
            if (proxyDecorator != null)
            {
                //    proxyDecorator.Target = target ?? serviceProvider.GetRequiredService<T>();// Activator.CreateInstance<T>();
                proxyDecorator._serviceId = serviceId;
            }

            return proxy;
    }

}