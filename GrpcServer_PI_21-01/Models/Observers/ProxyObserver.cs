using System.Data;

namespace GrpcServer_PI_21_01.Models.Observers
{
    public class ProxyObserver : IObserver
    {

        static ProxyObserver()
        {
            var proxyObserver = new ProxyObserver();
            Subject.Instance.RegisterObserver(proxyObserver);
        }

        public void Update<T>(ObserverArguments<T> ob)
        {
            ob.CacheProxy?.Reset();
        }
    }
}