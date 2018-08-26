using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using VoluntarAe.Web.Models;

namespace VoluntarAe.Web.Helper
{
    public class ApiHelper
    {
        private readonly HttpClient _client;

        public ApiHelper()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://voluntaraeapi20180825020524.azurewebsites.net/")
            };
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        #region Category
        public async Task<HttpResponseMessage> GetCategory(int id)
        {
            return await _client.GetAsync($"api/Category/{id}");
        }

        public async Task<HttpResponseMessage> GetAllCategories()
        {
            return await _client.GetAsync($"api/Category");
        }

        public async Task<HttpResponseMessage> UpdateCategory(int id, CategoryBindingViewModels model)
        {
            return await _client.PutAsJsonAsync($"api/Category/{model.id}/", model);
        }

        public async Task<HttpResponseMessage> InsertCategory(CategoryBindingViewModels model)
        {
            return await _client.PostAsJsonAsync("api/Category", model);
        }

        public async Task<HttpResponseMessage> DeleteCategory(int id)
        {
            return await _client.DeleteAsync($"api/Category/{id}");
        }
        #endregion

        #region Details
        public async Task<HttpResponseMessage> GetDetail(int id)
        {
            return await _client.GetAsync($"api/Details/{id}");
        }

        public async Task<HttpResponseMessage> GetAllDetail()
        {
            return await _client.GetAsync($"api/Details");
        }

        public async Task<HttpResponseMessage> UpdateDetail(int id, DetailsCreateEditViewModel model)
        {
            return await _client.PutAsJsonAsync($"api/Details/{model.id}/", model);
        }

        public async Task<HttpResponseMessage> InsertDetail(DetailsCreateEditViewModel model)
        {
            return await _client.PostAsJsonAsync("api/Details", model);
        }

        public async Task<HttpResponseMessage> DeleteDetail(int id)
        {
            return await _client.DeleteAsync($"api/Details/{id}");
        }
        #endregion
    }
}