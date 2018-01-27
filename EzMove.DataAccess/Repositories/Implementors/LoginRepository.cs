using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.DataAccess.Repositories.Implementors
{
    public class LoginRepository : ILoginRepository
    {
        private IDbHelper dbHelper = null;
        public LoginRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public LoginResponse LoginUser(Login user)
        {
            LoginResponse lr = CreateUser(user);
            
            if (lr != null)
                CreateToken(lr);

            return lr;
        }

        public OpResponse ChangeProfile(Profile profile)
        {
            OpResponse orp = new OpResponse();
            orp.IsSuccess = false;
            using (IDbConnection dbConnection = dbHelper.GetConnection())
            {
                using (IDbCommand dbCommand = dbHelper.GetCommand("updateprofile", CommandType.StoredProcedure, dbConnection))
                {
                    dbHelper.AddParameter("userlogin", profile.LoginId, dbCommand);
                    dbHelper.AddParameter("newpassword", profile.NewPassword, dbCommand);
                    dbHelper.AddParameter("phoneNumber", profile.PhoneNumber, dbCommand);
                    dbHelper.AddParameter("DName", profile.DisplayName, dbCommand);
                    if (dbCommand.ExecuteNonQuery() > 0)
                    {
                        orp.IsSuccess = true;
                        orp.OpMsg = "Profile changed successfully";
                    }
                }
            }
            return orp;
        }

        public OpResponse GetPassword(string LoginId)
        {
            OpResponse orp = new OpResponse();
            orp.IsSuccess = false;
            using (IDbConnection dbConnection = dbHelper.GetConnection())
            {
                using (IDbCommand dbCommand = dbHelper.GetCommand("getpassword", CommandType.StoredProcedure, dbConnection))
                {
                    dbHelper.AddParameter("userlogin", LoginId, dbCommand);
                    using (IDataReader dr = dbCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orp.IsSuccess = true;
                            orp.OpMsg = dr["userpassword"].ToString();
                        }
                    }
                    if (!orp.IsSuccess)
                        orp.OpMsg = "Not able to find User";
                }
            }
            return orp;
        }

        public string GetEmail( string LoginID )
        {
            string email = string.Empty;

            using (IDbConnection dbConnection = dbHelper.GetConnection())
            {
                using (IDbCommand dbCommand = dbHelper.GetCommand("getuserbyid", CommandType.StoredProcedure, dbConnection))
                {
                    dbHelper.AddParameter("LogID", LoginID, dbCommand);

                    using (IDataReader dr = dbCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            email = dr["Email"].ToString();
                        }
                    }
                }
            }
            return email;
        }
        public LoginResponse GetUserByID(string LoginID)
        {
            LoginResponse lr = null;

            using (IDbConnection dbConnection = dbHelper.GetConnection())
            {
                using (IDbCommand dbCommand = dbHelper.GetCommand("getuserbyloginid", CommandType.StoredProcedure, dbConnection))
                {
                    dbHelper.AddParameter("userlogin", LoginID, dbCommand);
                    using (IDataReader dr = dbCommand.ExecuteReader())
                    {
                        lr = DataMapper.ConvertLoginFromDR(dr); 
                    }
                }
            }
            return lr;
        }

        public LoginResponse GetUser(string Token)
        {
            LoginResponse lr = null;
            using (IDbConnection dbConnection = dbHelper.GetConnection())
            {
                using (IDbCommand dbCommand = dbHelper.GetCommand("getsession", CommandType.StoredProcedure, dbConnection))
                {
                    dbHelper.AddParameter("token", Token, dbCommand);
                    using (IDataReader dr = dbCommand.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lr = new LoginResponse();
                            lr.UserID = Convert.ToInt32(dr["UserID"]);
                            lr.FirebaseID = dr["FirebaseID"].ToString();
                            lr.LoginID = dr["LoginID"].ToString();
                            break;
                        }
                    }
                }
            }
            return lr;
        }

        private LoginResponse CreateUser( Login login)
        {
            LoginResponse lr = null;

            using (IDbConnection dbConnection = dbHelper.GetConnection())
            {
                using (IDbCommand dbCommand = dbHelper.GetCommand("loginuser", CommandType.StoredProcedure, dbConnection))
                {
                    dbHelper.AddParameter("userlogin", login.LoginId, dbCommand);
                    dbHelper.AddParameter("userpwd", login.Password, dbCommand);

                    using (IDataReader dr = dbCommand.ExecuteReader())
                    {
                        lr = DataMapper.ConvertLoginFromDR(dr);
                        lr.LoginID = login.LoginId;
                        lr.FirebaseID = login.FirebaseID;
                    }
                }
            }
            return lr; 
        }

        private void CreateToken( LoginResponse lr )
        {
            lr.Token = Guid.NewGuid();
            using (IDbConnection dbConnection = dbHelper.GetConnection())
            {
                using (IDbCommand dbCommand = dbHelper.GetCommand("createsession", CommandType.StoredProcedure, dbConnection))
                {
                    dbHelper.AddParameter("token", lr.Token, dbCommand);
                    dbHelper.AddParameter("loginid", lr.UserID, dbCommand);
                    dbHelper.AddParameter("FBID", lr.FirebaseID, dbCommand);
                    dbHelper.AddParameter("userid", lr.UserID, dbCommand);
                    dbCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
