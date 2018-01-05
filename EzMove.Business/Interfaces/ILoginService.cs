using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Business
{
    public interface ILoginService
    {
        LoginResponse LoginUser(Login user);
    }
}
