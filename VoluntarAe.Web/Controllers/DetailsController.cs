using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VoluntarAe.Web.Helper;
using VoluntarAe.Web.Models;

namespace VoluntarAe.Web.Controllers
{
    public class DetailsController : Controller
    {
        private ApiHelper _clientHelper = new ApiHelper();

        // GET: Details
        public async Task<ActionResult> Index()
        {
            var response = await _clientHelper.GetAllDetail();

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<List<DetailsBindingViewModels>>();

                return View(model);
            }

            return View();
        }

        // GET: Details/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _clientHelper.GetDetail(id);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<DetailsBindingViewModels>();

                return View(model);
            }

            return View();
        }

        // GET: Details/Create
        public async Task<ActionResult> Create()
        {
            var categories = new List<CategoryBindingViewModels>();
            var response = await _clientHelper.GetAllCategories();
            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<CategoryBindingViewModels>>(category);
            }

            var model = new DetailsCreateEditViewModel();
            var list = new List<SelectListItem>();

            foreach (var cat in categories)
            {
                var selectListItem = new SelectListItem
                {
                    Value = ((int)cat.id).ToString(),
                    Text = cat.title,
                    Selected = cat.id == model.categoryId
                };
                list.Add(selectListItem);
            }
            model.categoryName = list;

            return View(model);
        }

        // POST: Details/Create
        [HttpPost]
        public async Task<ActionResult> Create(DetailsCreateEditViewModel model)
        {
            try
            {
                var response = await _clientHelper.InsertDetail(model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Details/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = new DetailsCreateEditViewModel();
            var categories = new List<CategoryBindingViewModels>();
            var response = await _clientHelper.GetDetail(id);

            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<DetailsCreateEditViewModel>();
            }

            response = await _clientHelper.GetAllCategories();
            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<CategoryBindingViewModels>>(category);
            }

            var list = new List<SelectListItem>();

            foreach (var cat in categories)
            {
                var selectListItem = new SelectListItem
                {
                    Value = ((int)cat.id).ToString(),
                    Text = cat.title,
                    Selected = cat.id == model.categoryId
                };
                list.Add(selectListItem);
            }

            model.categoryName = list;           

            return View(model);
        }

        // POST: Details/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, DetailsCreateEditViewModel model)
        {
            try
            {
                var response = await _clientHelper.UpdateDetail(id, model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Details/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = new DetailsBindingViewModels();
            var response = await _clientHelper.GetDetail(id);

            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<DetailsBindingViewModels>();
            }

            return View(model);
        }

        // POST: Details/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, DetailsBindingViewModels model)
        {
            try
            {
                var response = await _clientHelper.DeleteDetail(id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
