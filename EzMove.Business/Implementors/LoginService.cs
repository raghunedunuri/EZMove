using EzMove.Cache;
using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
