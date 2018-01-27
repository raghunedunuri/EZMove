using EzMove.Cache;
using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using EzMove.MQUtilities;

namespace EzMove.Business
{
    public class LoginService : ILoginService
    {
        private ILoginRepository loginRepos = null;
        private IEmployeeRepository employeeRepository = null;
        public LoginService(ILoginRepository loginRepos, IEmployeeRepository employeeRepository)
        {
            this.loginRepos = loginRepos;
            this.employeeRepository = employeeRepository;
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
            LoginResponse lr = loginRepos.GetUserByID(LoginId);
            if (lr != null)
            {
                OpResponse.IsSuccess = true;
                OpResponse.OpMsg = string.Format("Email sent to {0}", lr.Email);
                MQBatchRequest batchRequest = new MQBatchRequest()
                {
                    EventType = EventDef.FORGOTPASSWORD,
                    MessageData = lr
                };
                MQManager.QueueEmployeeUpdate(batchRequest);
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
