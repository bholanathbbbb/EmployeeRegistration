using System;
using System.Linq;
using DataAccess;

namespace Presenter
{
    public class SignInPresenter : Presenter<ISignIn>
    {
        DataAccess.DA _singInDA;
        public SignInPresenter()
        {
            _singInDA = new DA();
        }
        
        public bool SignIn()
        {
            try
            {

                return _singInDA.SignIn(SelectedView.UserInfo);
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

    }
}
