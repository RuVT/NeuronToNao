using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronReaderConsole.Patterns
{
    public class NeuronDataReaderHandler : IObservable<float[]>
    {
        protected ConcurrentBag<IObserver<float[]>> inputObservers = new ConcurrentBag<IObserver<float[]>>();
        protected float[] _valuesBuffer = new float[354];

        public IDisposable Subscribe(IObserver<float[]> observer)
        {
            if (!inputObservers.Contains(observer))
            {
                inputObservers.Add(observer);
                observer.OnNext(_valuesBuffer);
            }
            return new Unsubscriber(inputObservers, observer);
        }
    }

    internal class Unsubscriber : IDisposable
    {
       private ConcurrentBag<IObserver<float[]>> _observers;
       private IObserver<float[]> _observer;

       internal Unsubscriber(ConcurrentBag<IObserver<float[]>> observers, IObserver<float[]> observer)
       {
          this._observers = observers;
          this._observer = observer;
       }

       public void Dispose() 
       {
          if (_observers.Contains(_observer))
             _observers.TryTake(out _observer);
       }
    }
}
