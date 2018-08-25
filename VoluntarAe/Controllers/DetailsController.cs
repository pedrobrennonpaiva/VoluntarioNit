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

namespace VoluntarAe.Controllers
{
    public class DetailsController : ApiController
    {
        private readonly string connectionString;

        public DetailsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // GET: api/Feed
        public IEnumerable<DetailsModel> Get()
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
                                categoryId = (int) reader["categoryId"],
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
        
        public DetailsModel Get(int id)
        {
            var model = new DetailsModel();

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
                            model = new DetailsModel
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
        
        public void Post(DetailsModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "addDetails";
                var command = new SqlCommand(commandText, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", model.title);
                command.Parameters.AddWithValue("@image", model.image);
                command.Parameters.AddWithValue("@subTitle", model.subTitle);
                command.Parameters.AddWithValue("@date", model.date);
                command.Parameters.AddWithValue("@hour", model.hour);
                command.Parameters.AddWithValue("@place", model.place);
                command.Parameters.AddWithValue("@description", model.description);
                command.Parameters.AddWithValue("@tags", model.tags);
                command.Parameters.AddWithValue("@youtube", model.youtube);
                command.Parameters.AddWithValue("@organizer", model.organizer);
                command.Parameters.AddWithValue("@phone", model.phone);
                command.Parameters.AddWithValue("@categoryId", model.categoryId);

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
        
        public void Put(int id, DetailsModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "updateDetail";
                var command = new SqlCommand(commandText, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", model.id);
                command.Parameters.AddWithValue("@title", model.title);
                command.Parameters.AddWithValue("@image", model.image);
                command.Parameters.AddWithValue("@subTitle", model.subTitle);
                command.Parameters.AddWithValue("@date", model.date);
                command.Parameters.AddWithValue("@hour", model.hour);
                command.Parameters.AddWithValue("@place", model.place);
                command.Parameters.AddWithValue("@description", model.description);
                command.Parameters.AddWithValue("@tags", model.tags);
                command.Parameters.AddWithValue("@youtube", model.youtube);
                command.Parameters.AddWithValue("@organizer", model.organizer);
                command.Parameters.AddWithValue("@phone", model.phone);
                command.Parameters.AddWithValue("@categoryId", model.categoryId);

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
                var commandText = "deleteDetail";
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
