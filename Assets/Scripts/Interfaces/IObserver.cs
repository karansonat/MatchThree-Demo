using System;

namespace MatchThree.Core
{
    public interface IObserver<T> where T : EventArgs
    {
        void OnNotified(object sender, T eventArgs);
    }
}