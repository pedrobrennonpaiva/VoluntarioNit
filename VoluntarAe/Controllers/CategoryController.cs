using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VoluntarAe.Controllers;
using WebApplication.API.Models;

namespace WebApplication.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly string connectionString;
        List<DetailsModel> detailsModels;
        List<DetailsModel> detailsListModels;
        List<DetailsModel> listDet = null;

        public CategoryController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private List<DetailsModel> GetDetails()
        {
            var list = new List<DetailsModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "readDetails";
                var command = new SqlCommand(procedureName, connection);

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var model = new DetailsModel
                            {
                                id = (int)reader["id"],
                                title = reader["title"].ToString(),
                                subTitle = reader["subtitle"].ToString(),
                                image = reader["image"].ToString(),
                                date = reader["date"].ToString(),
                                hour = reader["hour"].ToString(),
                                place = reader["place"].ToString(),
                                description = reader["description"].ToString(),
                                tags = reader["tags"].ToString(),
                                youtube = reader["youtube"].ToString(),
                                organizer = reader["organizer"].ToString(),
                                phone = reader["phone"].ToString(),
                                categoryId = (int)reader["categoryId"],
                                categoryName = reader["categoryName"].ToString()
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
        
        public IEnumerable<CategoryModel> Get()
        {
            detailsListModels = GetDetails();
            listDet = new List<DetailsModel>();
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
                            detailsModels = new List<DetailsModel>();
                            int idDef = (int)reader["id"];

                            foreach (var det in detailsListModels)
                            {
                                if (det.categoryId.Equals(idDef)){
                                    detailsModels.Add(det);
                                }
                            }

                            var model = new CategoryModel
                            {
                                id = (int)reader["id"],
                                title = reader["title"].ToString(),
                                detailsList = detailsModels != null ? detailsModels : listDet
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
            detailsModels = new List<DetailsModel>();
            listDet = new List<DetailsModel>();
            var model = new CategoryModel();

            using (var connection = new SqlConnection(connectionString))
            {
                var procedureName = "readCategory";
                var command = new SqlCommand(procedureName, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            int idDef = (int)reader["id"];

                            foreach (var det in detailsModels)
                            {
                                if (det.categoryId.Equals(idDef))
                                {
                                    detailsModels.ToList().Add(det);
                                }
                            }

                            model = new CategoryModel
                            {
                                id = (int)reader["id"],
                                title = reader["title"].ToString(),
                                detailsList = detailsModels != null ? detailsModels : listDet
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
                command.Parameters.AddWithValue("@title", String.IsNullOrEmpty(model.title) ? "" : model.title);

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
                command.Parameters.AddWithValue("@title", String.IsNullOrEmpty(model.title) ? "" : model.title);

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
