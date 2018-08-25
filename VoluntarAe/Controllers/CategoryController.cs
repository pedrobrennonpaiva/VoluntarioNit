using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.API.Models;

namespace WebApplication.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly string connectionString;

        public CategoryController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        
        public IEnumerable<CategoryModel> Get()
        {
            var list = new List<CategoryModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "readCategories";
                var command = new SqlCommand(procedureName, connection);

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var model = new CategoryModel
                            {
                                id = (int)reader["id"],
                                title = reader["title"].ToString()
                            };
                            list.Add(model);
                        }
                    }

                }
                finally
                {
                    connection.Close();
                }
            }
            return list;
        }
        
        public CategoryModel Get(int id)
        {
            var model = new CategoryModel();

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "readCategory";
                var command = new SqlCommand(procedureName, connection);

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            model = new CategoryModel
                            {
                                id = (int)reader["id"],
                                title = reader["title"].ToString()
                            };
                        }
                    }

                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }
        
        public void Post(CategoryModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "addCategory";
                var command = new SqlCommand(commandText, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", model.title);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        public void Put(int id, CategoryModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "updateCategory";
                var command = new SqlCommand(commandText, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", model.id);
                command.Parameters.AddWithValue("@title", model.title);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "deleteCategory";
                var command = new SqlCommand(commandText, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
