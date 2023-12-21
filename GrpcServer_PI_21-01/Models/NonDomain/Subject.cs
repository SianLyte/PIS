using System.Reflection;

namespace GrpcServer_PI_21_01.Models
{
    public class Subject : ISubject
    {
        private readonly List<IObserver> observers = new List<IObserver>();
        public static Subject Instance {
            get {
                if (_subject is null)
                {
                    _subject = new Subject();
                }
                return _subject; 
            }
        }

        private static Subject _subject;

        private Subject()
        {
            //observers = Assembly.GetExecutingAssembly().GetTypes()
            //  .Where(t => t.GetInterface(nameof(IObserver)) != null)
            //  .Select(t => t.GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<object>())
            //  .Cast<IObserver>()
            //  .ToList();
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Any(o => o.GetType().Name == observer.GetType().Name))
                observers.Add(observer);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers<T>(ObserverArguments<T> arguments)
        {
            foreach (var observer in observers)
            {
                observer.Update(arguments);
            }
        }
    }
}
