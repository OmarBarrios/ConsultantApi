using ConsultantApi.Data_access.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Data_access.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ClientMysql clientDb = new ClientMysql();

        public async Task<List<EmployeeEntity>> GetAll()
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var query = clientDb.Run().CreateCommand();
                query.CommandText = "SELECT * FROM employees WHERE (deleted_at is null)";
                var result = await query.ExecuteReaderAsync();

                List<EmployeeEntity> employee = GenerateListOfEmployees((MySqlDataReader)result);
                return employee;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<EmployeeEntity> GetByUuid(string uuid)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var sql = $"SELECT * FROM employees WHERE uuid = @uuid";
                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Prepare();

                var result = await cmd.ExecuteReaderAsync();
                EmployeeEntity employee = GenerateAEmployee((MySqlDataReader)result);

                return employee;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<EmployeeEntity> Create(EmployeeEntity employee)
        {
            try
            {
                clientDb.Run().Open();
                var sql = @"INSERT INTO employees(
                                        uuid,
                                        name,
                                        birthday,
                                        nationality,
                                        chapter_area,
                                        email,
                                        project_assigned,
                                        created_at,
                                        updated_at)
                            VALUES(
                                        @uuid,
                                        @name,
                                        @birthday,
                                        @nationality,
                                        @chapter_area,
                                        @email,
                                        @project_assigned,
                                        @created_at,
                                        @updated_at)";
                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", employee.Uuid);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@birthday", employee.Birthday);
                cmd.Parameters.AddWithValue("@nationality", employee.Nationality);
                cmd.Parameters.AddWithValue("@chapter_area", employee.ChapterArea);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@project_assigned", employee.ProjectAssigned);
                cmd.Parameters.AddWithValue("@created_at", employee.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", employee.Updated_at);
                cmd.Prepare();
                await cmd.ExecuteReaderAsync();

                clientDb.Run().Close();
                return employee;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<EmployeeEntity> Update(string uuid, EmployeeEntity employee)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();
                var sql = @"UPDATE employees SET
                                name= @name,
                                birthday= @birthday,
                                nationality= @nationality,
                                chapter_area= @chapter_area,
                                email= @email,
                                project_assigned= @project_assigned,
                                updated_at= @updated_at
                            WHERE uuid = @uuid";

                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", employee.Uuid);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@birthday", employee.Birthday);
                cmd.Parameters.AddWithValue("@nationality", employee.Nationality);
                cmd.Parameters.AddWithValue("@chapter_area", employee.ChapterArea);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@project_assigned", employee.ProjectAssigned);
                cmd.Parameters.AddWithValue("@updated_at", employee.Updated_at);
                cmd.Prepare();
                await cmd.ExecuteReaderAsync();

                clientDb.Run().Close();
                return employee;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Boolean> Delete(string uuid, DateTime employeeDeleted)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var sql = @"UPDATE employees SET deleted_at = @deleted_at
                            WHERE uuid = @uuid";

                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Parameters.AddWithValue("@deleted_at", employeeDeleted);
                cmd.Prepare();

                var result = await cmd.ExecuteReaderAsync();
                clientDb.Run().Close();

                Boolean employeeIsDeleted = await IsDeleted(uuid);
                return employeeIsDeleted;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<EmployeeEntity> GenerateListOfEmployees(MySqlDataReader result)
        {
            try
            {
                List<EmployeeEntity> employees = new List<EmployeeEntity>();

                while (result.Read())
                {
                    EmployeeEntity employee = new EmployeeEntity(
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        (DateTime)result.GetMySqlDateTime("birthday"),
                        result.GetString("nationality"),
                        result.GetString("chapter_area"),
                        result.GetString("email"),
                        result.GetGuid("project_assigned"),
                        (DateTime)result.GetMySqlDateTime("created_at"),
                        (DateTime)result.GetMySqlDateTime("updated_at")
                   );

                    employees.Add(employee);
                }
                result.Close();

                return employees;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private EmployeeEntity GenerateAEmployee(MySqlDataReader result)
        {
            try
            {
                EmployeeEntity company = new EmployeeEntity();

                while (result.Read())
                {
                    company = new EmployeeEntity(
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        (DateTime)result.GetMySqlDateTime("birthday"),
                        result.GetString("nationality"),
                        result.GetString("chapter_area"),
                        result.GetString("email"),
                        result.GetGuid("project_assigned"),
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
                EmployeeEntity result = await GetByUuid(uuid);

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