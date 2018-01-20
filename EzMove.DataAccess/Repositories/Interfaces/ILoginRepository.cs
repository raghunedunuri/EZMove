using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.DataAccess.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        LoginResponse LoginUser(Login user);

        OpResponse ChangeProfile(Profile profile);

        OpResponse GetPassword(string LoginId);

        string GetEmail(string LoginID);
    }
}
