using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Implementors;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Cache
{
    public class CacheImplementor
    {
        public static Dictionary<string, LoginResponse> UserLogins;
        public static IDbHelper dbHelper;

        static CacheImplementor()
        {
            UserLogins = new Dictionary<string, LoginResponse>();
            dbHelper = new MySqlDbHelper(new MySqlConnectionManager());
        }

        public static void UpdateUser( LoginResponse lr )
        {
             UserLogins[lr.Token.ToString().ToLower()] = lr;
        }

        public static LoginResponse GetUserInfo ( string Token )
        {
            if (!UserLogins.ContainsKey(Token))
            { 
                LoginResponse lr = null;
                dbHelper.CreateCommand("getsession", System.Data.CommandType.StoredProcedure);
                dbHelper.AddParameter("token", Token);

                IDataReader dr = dbHelper.ExecuteReader();

                while (dr.Read())
                {
                    lr = new LoginResponse();
                    lr.UserID = Convert.ToInt32(dr["UserID"]);
                    lr.FirebaseID = dr["FirebaseID"].ToString();
                    lr.LoginID = dr["LoginID"].ToString();
                    UserLogins[Token.ToString().ToLower()] = lr;
                    break;
                }
                dr.Close();
            }
            return UserLogins[Token.ToString().ToLower()];
        }
    }
}
