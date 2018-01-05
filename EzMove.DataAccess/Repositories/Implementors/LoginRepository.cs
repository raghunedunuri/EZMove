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
            LoginResponse lr = null;

            dbHelper.CreateCommand("loginuser", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("userlogin", user.LoginId);
            dbHelper.AddParameter("userpwd", user.Password);

            IDataReader dr = dbHelper.ExecuteReader();
            
            while (dr.Read())
            {
                lr = new LoginResponse();

                lr.UserID  = Convert.ToInt32(dr["USERID"]);
                lr.LoginID = user.LoginId;
                lr.PhoneNumber = dr["Phone"].ToString();
                lr.Email = dr["Email"].ToString();
                lr.UserType = dr["UserType"].ToString();
                lr.Name = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                lr.Gender = dr["Gender"].ToString();
                lr.PicUrl = dr["Photo"].ToString();
                break;
            }
            dr.Close();
            if (lr != null)
                CreateToken(lr);

            return lr;
        }
        
        private void CreateToken( LoginResponse lr )
        {
            lr.Token = Guid.NewGuid();
            dbHelper.CreateCommand("createsession", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("token", lr.Token);
            dbHelper.AddParameter("loginid", lr.UserID);
            dbHelper.ExecuteNonQuery();
        }


    }
}
