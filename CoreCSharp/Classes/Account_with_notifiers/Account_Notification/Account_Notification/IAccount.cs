using System.Collections.Generic;

namespace csharp.training.congruent.apps
{
    internal interface IAccount
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}