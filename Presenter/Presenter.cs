using System;
using System.Linq;

namespace Presenter
{
    public class Presenter<T> : IPresenter<T>
    {
        public T SelectedView { get; set; }
    }
}
