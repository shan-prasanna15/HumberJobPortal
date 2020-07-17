﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : SystemCountryCodeRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();

            foreach(SecurityLoginsLogPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                                                ([Id]
                                                ,[Login]
                                                ,[Source_IP]
                                                ,[Logon_Date]
                                                ,[Is_Succesful])
                                            VALUES
                                                (@Id
                                                ,@Login
                                                ,@Source_IP
                                                ,@Logon_Date
                                                ,@Is_Succesful)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);

                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = @"SELECT *
                                FROM [dbo].[Security_Logins_Log]";
            SqlDataReader rdr = cmd.ExecuteReader();
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1900];
            int x = 0;

            while (rdr.Read())
            {
                SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Login = rdr.GetGuid(1);
                poco.SourceIP = rdr.GetString(2);
                poco.LogonDate = rdr.GetDateTime(3);
                poco.IsSuccesful = rdr.GetBoolean(4);

                pocos[x] = poco;
                x++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            pocos = pocos.Where(p => p != null);
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();

            foreach(SecurityLoginsLogPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins_Log]
                                            WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseAdo.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();

            foreach (SecurityLoginsLogPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Log]
                                       SET [Login] = @Login
                                          ,[Source_IP] = @Source_IP
                                          ,[Logon_Date] = @Logon_Date
                                          ,[Is_Succesful] = @Is_Succesful
                                     WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);

                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
