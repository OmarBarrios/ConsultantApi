using ConsultantApi.Data_access.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Data_access.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        ClientMysql clientDb = new ClientMysql();
        public async Task<List<ProjectEntity>> GetAll()
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var query = clientDb.Run().CreateCommand();
                query.CommandText = "SELECT * FROM projects WHERE (deleted_at is null)";
                var result = await query.ExecuteReaderAsync();

                List<ProjectEntity> projects = GenerateListOfProjects((MySqlDataReader)result);
                return projects;
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ProjectEntity> GetByUuid(string uuid)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var sql = $"SELECT * FROM projects WHERE uuid = @uuid";
                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Prepare();

                var result = await cmd.ExecuteReaderAsync();
                ProjectEntity project = GenerateAProject((MySqlDataReader)result);

                return project;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ProjectEntity> Create(ProjectEntity project)
        {
            try
            {
                clientDb.Run().Open();
                var sql = @"INSERT INTO projects(
                                        uuid,
                                        name,
                                        company_assigned,
                                        start_date,
                                        created_at,
                                        updated_at)
                            VALUES(
                                        @uuid,
                                        @name,
                                        @company_assigned,
                                        @start_date,
                                        @created_at,
                                        @updated_at)";
                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", project.Uuid);
                cmd.Parameters.AddWithValue("@name", project.Name);
                cmd.Parameters.AddWithValue("@company_assigned", project.CompanyAssigned);
                cmd.Parameters.AddWithValue("@start_date", project.StartDate);
                cmd.Parameters.AddWithValue("@created_at", project.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", project.Updated_at);
                cmd.Prepare();
                await cmd.ExecuteReaderAsync();

                clientDb.Run().Close();
                return project;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ProjectEntity> Update(string uuid, ProjectEntity project)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();
                var sql = @"UPDATE projects SET
                                name= @name,
                                company_assigned= @company_assigned,
                                start_date= @start_date,
                                updated_at= @updated_at
                            WHERE uuid = @uuid";

                var cmd = new MySqlCommand(sql, clientDb.Run());

                cmd.Parameters.AddWithValue("@uuid", project.Uuid);
                cmd.Parameters.AddWithValue("@name", project.Name);
                cmd.Parameters.AddWithValue("@company_assigned", project.CompanyAssigned);
                cmd.Parameters.AddWithValue("@start_date", project.StartDate);
                cmd.Parameters.AddWithValue("@updated_at", project.Updated_at);
                cmd.Prepare();
                await cmd.ExecuteReaderAsync();

                clientDb.Run().Close();
                return project;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Boolean> Delete(string uuid, DateTime projectDeleted)
        {
            try
            {
                clientDb = new ClientMysql();
                clientDb.Run().Open();

                var sql = @"UPDATE projects SET deleted_at = @deleted_at
                            WHERE uuid = @uuid";

                var cmd = new MySqlCommand(sql, clientDb.Run());
                cmd.Parameters.AddWithValue("@uuid", uuid);
                cmd.Parameters.AddWithValue("@deleted_at", projectDeleted);
                cmd.Prepare();

                var result = await cmd.ExecuteReaderAsync();
                clientDb.Run().Close();

                Boolean projectIsDeleted = await IsDeleted(uuid);
                return projectIsDeleted;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<ProjectEntity> GenerateListOfProjects(MySqlDataReader result)
        {
            try
            {
                List<ProjectEntity> projects = new List<ProjectEntity>();

                while (result.Read())
                {
                    ProjectEntity project = new ProjectEntity(
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        result.GetGuid("company_assigned"),
                        (DateTime)result.GetMySqlDateTime("start_date"),
                        (DateTime)result.GetMySqlDateTime("created_at"),
                        (DateTime)result.GetMySqlDateTime("updated_at")
                   );

                    projects.Add(project);
                }
                result.Close();

                return projects;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private ProjectEntity GenerateAProject(MySqlDataReader result)
        {
            try
            {
                ProjectEntity project = new ProjectEntity();

                while (result.Read())
                {
                    project = new ProjectEntity(
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        result.GetGuid("company_assigned"),
                        (DateTime)result.GetMySqlDateTime("start_date"),
                        (DateTime)result.GetMySqlDateTime("created_at"),
                        (DateTime)result.GetMySqlDateTime("updated_at")
                   );
                }

                result.Close();
                return project;
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
                ProjectEntity result = await GetByUuid(uuid);

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