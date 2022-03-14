using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Entities;
using Transport.DAL.Entities.Response;
using Transport.DAL.Interfaces;
using Transport.DAL.Interfaces.IRepositories;

namespace Transport.DAL.Repositories
{
    public class ModelRepository : IModelRepository
    {
        protected IConnectionFactory _connectionFactory;

        public ModelRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            List<Model> models = new List<Model>();
            using (SqlConnection con = (SqlConnection)_connectionFactory.GetSqlConnection)
            {
                SqlCommand cmd = new SqlCommand("GetAllFromTable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterTabel = new SqlParameter("@P_tableName", SqlDbType.NVarChar, 50);
                parameterTabel.Value = "Model";
                cmd.Parameters.Add(parameterTabel);
                if (con.State != ConnectionState.Open) await con.OpenAsync();

                using(SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                    while (await rdr.ReadAsync())
                    {
                        Model model = new Model();
                        model.Id = Convert.ToInt32(rdr["Id"]);
                        model.Name = rdr["Name"].ToString();
                        model.MakeId = Convert.ToInt32(rdr["MakeId"]);

                        models.Add(model);
                    }
                await con.CloseAsync();
            }
            return models;
        }

        public async Task<IEnumerable<Model>> GetAllDetailAsync()
        {
            List<Model> models = new List<Model>();
            using (SqlConnection con = (SqlConnection)_connectionFactory.GetSqlConnection)
            {
                string query = "SELECT Mk.Id AS MkId, Mk.Name AS MkName, Md.Id AS MdId, Md.Name AS MdName " +
                               "FROM Model AS Md " +
                               "JOIN Make AS Mk " +
                               "ON Md.MakeId = Mk.Id";
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State != ConnectionState.Open) await con.OpenAsync();

                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                    while (await rdr.ReadAsync())
                    {
                        Model model = new Model();
                        model.Id = Convert.ToInt32(rdr["MdId"]);
                        model.Name = rdr["MdName"].ToString();
                        model.MakeId = Convert.ToInt32(rdr["MkId"]);
                        Make make = new Make() { Id = model.MakeId, Name = rdr["MkName"].ToString() };
                        model.Make = make;

                        models.Add(model);
                    }
                await con.CloseAsync();
            }
            return models;
        }

        public async Task<Model> GetAsync(int Id)
        {
            Model model = new Model();
            using (SqlConnection con = (SqlConnection)_connectionFactory.GetSqlConnection)
            {
                SqlCommand cmd = new SqlCommand("GetByIdFromTable", con);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterTabel = new SqlParameter("@P_tableName", SqlDbType.NVarChar, 50);
                parameterTabel.Value = "Model";
                cmd.Parameters.Add(parameterTabel);
                parameterTabel = new SqlParameter("@P_Id", SqlDbType.NVarChar);
                parameterTabel.Value = Id;
                cmd.Parameters.Add(parameterTabel);

                if (con.State != ConnectionState.Open) await con.OpenAsync();

                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                    while (await rdr.ReadAsync())
                    {
                        model.Id = Convert.ToInt32(rdr["Id"]);
                        model.Name = rdr["Name"].ToString();
                        model.MakeId = Convert.ToInt32(rdr["MakeId"]);
                    }
                await con.CloseAsync();
            }
            return model;
        }

        public async Task<Model> GetDetailAsync(int Id)
        {
            Model model = new Model();
            using (SqlConnection con = (SqlConnection)_connectionFactory.GetSqlConnection)
            {
                string query = "SELECT Mk.Id AS MkId, Mk.Name AS MkName, Md.Id AS MdId, Md.Name AS MdName " +
                               "FROM Model AS Md " +
                               "JOIN Make AS Mk " +
                               "ON Md.MakeId = Mk.Id " +
                               "WHERE Md.Id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter nameParam = new SqlParameter("@id", Id);
                cmd.Parameters.Add(nameParam);

                if (con.State != ConnectionState.Open) await con.OpenAsync();

                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                    while (await rdr.ReadAsync())
                    {
                        model.Id = Convert.ToInt32(rdr["MdId"]);
                        model.Name = rdr["MdName"].ToString();
                        model.MakeId = Convert.ToInt32(rdr["MkId"]);
                        Make make = new Make() { Id = model.MakeId, Name = rdr["MkName"].ToString() };
                        model.Make = make;
                    }
                await con.CloseAsync();
            }
            return model;
        }

        public async Task<int> AddAsync(Model entity)
        {
            int newId = 0;
            var columns = GetColumns();
            string tableName = "Model";
            var stringOfColumns = string.Join(", ", columns);
            var stringOfProperties = string.Join(", ", columns.Select(e => "@" + e));
            using (SqlConnection con = (SqlConnection)_connectionFactory.GetSqlConnection)
            {
                SqlCommand cmd = new SqlCommand("InsertToTable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_tableName", tableName);
                cmd.Parameters.AddWithValue("@P_columnsString", stringOfColumns);
                cmd.Parameters.AddWithValue("@P_propertiesString", stringOfProperties);
                if (con.State != ConnectionState.Open) await con.OpenAsync();

                string? query = Convert.ToString(await cmd.ExecuteScalarAsync());
                query += " SELECT SCOPE_IDENTITY()";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@MakeId", entity.MakeId);
                newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                await con.CloseAsync();
            }
            return newId;
        }

        public async Task UpdateAsync(Model entity)
        {
            var columns = GetColumns();
            string tableName = "Model";
            var stringOfColumns = string.Join(", ", columns.Where(e => e != "DateCreated").Select(e => $"{e} = @{e}"));
            using (SqlConnection con = (SqlConnection)_connectionFactory.GetSqlConnection)
            {
                SqlCommand cmd = new SqlCommand("UpdateInTable", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_tableName", tableName);
                cmd.Parameters.AddWithValue("@P_columnsString", stringOfColumns);
                cmd.Parameters.AddWithValue("@P_Id", entity.Id.ToString());
                if (con.State != ConnectionState.Open) await con.OpenAsync();

                string? query = Convert.ToString(await cmd.ExecuteScalarAsync());
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@MakeId", entity.MakeId);
                cmd.ExecuteNonQuery();
                await con.CloseAsync();
            }
        }

        public async Task DeleteAsync(int Id)
        {
            string tableName = "Model";
            using (SqlConnection con = (SqlConnection)_connectionFactory.GetSqlConnection)
            {
                SqlCommand cmd = new SqlCommand("DeleteFromTable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_tableName", tableName);
                cmd.Parameters.AddWithValue("@P_Id", Id.ToString());
                if (con.State != ConnectionState.Open) await con.OpenAsync();
                cmd.ExecuteNonQuery();
                await con.CloseAsync();
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(Model)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }
    }
}
