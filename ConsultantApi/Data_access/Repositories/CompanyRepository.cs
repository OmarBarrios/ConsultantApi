using ConsultantApi.Data_access.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Data_access.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        ClientMysql clientDb = new ClientMysql();
        public async Task<List<CompanyEntity>> GetAll()
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var query = clientDb.Run().CreateCommand();
                query.CommandText = "SELECT * FROM companies WHERE (deleted_at is null)";
                var result = await query.ExecuteReaderAsync();

                List<CompanyEntity> companies = GenerateListOfCompanies((MySqlDataReader)result);
                return companies;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<CompanyEntity> GetByUuid(string uuid)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var sql = $"SELECT * FROM companies WHERE uuid = @uuid";
                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Prepare();

                var result = await cmd.ExecuteReaderAsync();
                CompanyEntity company = GenerateACompany((MySqlDataReader)result);

                return company;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<CompanyEntity> Create(CompanyEntity company)
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
                await cmd.ExecuteReaderAsync();

                clientDb.Run().Close();
                return company;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<CompanyEntity> Update(string uuid, CompanyEntity company)
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
                await cmd.ExecuteReaderAsync();

                clientDb.Run().Close();
                return company;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Boolean> Delete(string uuid, DateTime companyDeleted)
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

                var result = await cmd.ExecuteReaderAsync();
                clientDb.Run().Close();

                Boolean companyIsDeleted = await IsDeleted(uuid);
                return companyIsDeleted;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<CompanyEntity> GenerateListOfCompanies(MySqlDataReader result)
        {
            try
            {
                List<CompanyEntity> companies = new List<CompanyEntity>();

                while (result.Read())
                {
                    CompanyEntity company = new CompanyEntity(
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        result.GetString("sector"),
                        result.GetString("address"),
                        result.GetString("start_date_partner"),
                        (DateTime)result.GetMySqlDateTime("created_at"),
                        (DateTime)result.GetMySqlDateTime("updated_at")
                   );

                    companies.Add(company);
                }
                result.Close();

                return companies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private CompanyEntity GenerateACompany(MySqlDataReader result)
        {
            try
            {
                CompanyEntity company = new CompanyEntity();

                while (result.Read())
                {
                    company = new CompanyEntity(
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        result.GetString("sector"),
                        result.GetString("address"),
                        result.GetString("start_date_partner"),
                        (DateTime)result.GetMySqlDateTime("created_at"),
                        (DateTime)result.GetMySqlDateTime("updated_at")
                   );
                }

                result.Close();
                return company;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private async Task<Boolean> IsDeleted(string uuid)
        {
            try
            {
                Boolean isDeleted = false;
                CompanyEntity result = await GetByUuid(uuid);

                if (result != null)
                {
                    isDeleted = true;
                }

                return isDeleted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}