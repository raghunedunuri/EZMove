using EzMove.Cache;
using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;

namespace EzMove.Business
{
    public class LoginService : ILoginService
    {
        private ILoginRepository loginRepos = null;
        public LoginService(ILoginRepository loginRepos)
        {
            this.loginRepos = loginRepos;
        }

        public LoginResponse LoginUser(Login user)
        {
            LoginResponse lr = loginRepos.LoginUser(user);
            if( lr != null ) //Update Cache
            {
                CacheImplementor.UpdateUser(lr);
            }
            return lr;
        }

        public OpResponse ChangeProfile(Profile profile)
        {
            return loginRepos.ChangeProfile(profile);
        }

        public OpResponse ForgotPassword(string LoginId)
        {
            OpResponse OpResponse = new OpResponse();
            string email = loginRepos.GetEmail(LoginId);
            if( string.IsNullOrEmpty(email))
            {
                OpResponse.IsSuccess = true;
                OpResponse.OpMsg = string.Format("Email sent to {0}", email);
            }
            else
            {
                OpResponse.IsSuccess = false;
                OpResponse.OpMsg = "User not exists";
            }
            return OpResponse;
        }
    }
}
