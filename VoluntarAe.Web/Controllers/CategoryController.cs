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
    public class CategoryController : Controller
    {
        private ApiHelper _clientHelper = new ApiHelper();

        // GET: Category
        public async Task<ActionResult> Index()
        {
            var response = await _clientHelper.GetAllCategories();

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<List<CategoryBindingViewModels>>();

                return View(model);
            }

            return View();
        }

        // GET: Category/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var response = await _clientHelper.GetCategory(id);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<CategoryBindingViewModels>();

                return View(model);
            }

            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public async Task<ActionResult> Create(CategoryBindingViewModels model)
        {
            try
            {
                var response = await _clientHelper.InsertCategory(model);

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

        // GET: Category/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = new CategoryBindingViewModels();
            var response = await _clientHelper.GetCategory(id);

            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<CategoryBindingViewModels>();
            }

            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, CategoryBindingViewModels model)
        {
            try
            {
                var response = await _clientHelper.UpdateCategory(id, model);

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

        // GET: Category/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = new CategoryBindingViewModels();
            var response = await _clientHelper.GetCategory(id);

            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<CategoryBindingViewModels>();
            }

            return View(model);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, CategoryBindingViewModels model)
        {
            try
            {
                var response = await _clientHelper.DeleteCategory(id);

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
