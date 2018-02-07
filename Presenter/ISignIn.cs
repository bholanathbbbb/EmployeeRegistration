using System;
using System.Linq;
using Domain;

namespace Presenter
{
    public interface ISignIn
    {
        User UserInfo { get; set; }
        event EventHandler SignMeUp;
    }
}
