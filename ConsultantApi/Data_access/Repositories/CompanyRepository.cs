using ConsultantApi.Data_access.Models;
using MySql.Data.MySqlClient;
using System;

namespace ConsultantApi.Data_access.Repositories
{
    public class CompanyRepository
    {
        ClientMysql clientDb = new ClientMysql();
        public MySqlDataReader GetAll()
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var query = clientDb.Run().CreateCommand();
                query.CommandText = "SELECT * FROM companies WHERE (deleted_at is null)";

                var result = query.ExecuteReader();

                return result;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public MySqlDataReader GetByUuid(string uuid)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var sql = $"SELECT * FROM companies WHERE uuid = @uuid";
                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Prepare();

                var result = cmd.ExecuteReader();

                return result;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public CompanyModel Create(CompanyModel company)
        {
            try
            {
                clientDb.Run().Open();
                var sql = @"INSERT INTO companies(
                                        uuid,
                                        sector,
                                        name,
                                        address,
                                        start_date_partner,
                                        created_at,
                                        updated_at)
                            VALUES(
                                        @uuid,
                                        @sector,
                                        @name,
                                        @address,
                                        @start_date_partner,
                                        @created_at,
                                        @updated_at)";
                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", company.Uuid);
                cmd.Parameters.AddWithValue("@sector", company.Sector);
                cmd.Parameters.AddWithValue("@name", company.Name);
                cmd.Parameters.AddWithValue("@address", company.Address);
                cmd.Parameters.AddWithValue("@start_date_partner", company.StartDatePartner.ToString());
                cmd.Parameters.AddWithValue("@created_at", company.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", company.Updated_at);
                cmd.Prepare();
                cmd.ExecuteReader();

                clientDb.Run().Close();
                return company;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public CompanyModel Update(string uuid, CompanyModel company)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();
                var sql = @"UPDATE companies SET
                                sector= @sector,
                                name= @name,
                                address= @address,
                                start_date_partner= @start_date_partner,
                                updated_at= @updated_at
                            WHERE uuid = @uuid";

                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Parameters.AddWithValue("@sector", company.Sector);
                cmd.Parameters.AddWithValue("@name", company.Name);
                cmd.Parameters.AddWithValue("@address", company.Address);
                cmd.Parameters.AddWithValue("@start_date_partner", company.StartDatePartner);
                cmd.Parameters.AddWithValue("@updated_at", company.Updated_at);
                cmd.Prepare();
                cmd.ExecuteReader();

                clientDb.Run().Close();
                return company;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public MySqlDataReader Delete(string uuid, DateTime companyDeleted)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var sql = @"UPDATE companies SET deleted_at = @deleted_at
                            WHERE uuid = @uuid";

                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Parameters.AddWithValue("@deleted_at", companyDeleted);
                cmd.Prepare();

                var result = cmd.ExecuteReader();
                clientDb.Run().Close();
                return result;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}