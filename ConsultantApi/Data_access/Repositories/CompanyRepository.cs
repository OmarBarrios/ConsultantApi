using ConsultantApi.Data_access.Models;
using ConsultantApi.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ConsultantApi.Data_access.Repositories
{
    public class CompanyRepository
    {
        private readonly ClientMysql clientDb = new ClientMysql();

        public CompanyModel Create(CompanyModel company)
        {
            try
            {
                clientDb.Run().Open();
                var sql = @"INSERT INTO companies(
                                        uuid,
                                        sector,
                                        address,
                                        start_date_partner,
                                        created_at,
                                        updated_at)
                            VALUES(
                                        @uuid,
                                        @sector,
                                        @address,
                                        @start_date_partner,
                                        @created_at,
                                        @updated_at)";
                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", company.Uuid);
                cmd.Parameters.AddWithValue("@sector", company.Sector);
                cmd.Parameters.AddWithValue("@address", company.Address);
                cmd.Parameters.AddWithValue("@start_date_partner", company.StartDatePartner.ToString());
                cmd.Parameters.AddWithValue("@created_at", company.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", company.Updated_at);
                cmd.Prepare();

                clientDb.Run().Close();
                return company;                             
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public MySqlDataReader GetAll()
        {
            try
            {
                clientDb.Run().Open();

                var query = clientDb.Run().CreateCommand();
                query.CommandText = "SELECT * FROM companies LIMIT 100";

                var result = query.ExecuteReader();

                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public MySqlDataReader GetByUuid(string uuid)
        {
            try
            {
                clientDb.Run().Open();

                var sql = $"SELECT * FROM companies WHERE uuid = @uuid";
                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Prepare();

                var result = cmd.ExecuteReader();

                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CompanyModel Update(string uuid, CompanyModel company)
        {
            try
            {
                clientDb.Run().Open();
                var sql = @"UPDATE companies SET
                                sector= @sector,
                                address= @address,
                                start_date_partner= @start_date_partner,
                                updated_at= @updated_at
                            WHERE uuid = @uuid";

                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Parameters.AddWithValue("@sector", company.Sector);
                cmd.Parameters.AddWithValue("@address", company.Address);
                cmd.Parameters.AddWithValue("@start_date_partner", company.StartDatePartner);
                cmd.Parameters.AddWithValue("@updated_at", company.Updated_at);
                cmd.Prepare();

                clientDb.Run().Close();
                return company;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public MySqlDataReader Delete(string uuid, string companyDeleted)
        {
            try
            {
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
            catch
            {
                throw new Exception();
            }
        }
    }
}