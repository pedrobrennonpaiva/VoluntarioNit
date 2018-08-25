using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoluntarAe.Web.Controllers
{
    public class WebController : Controller
    {
        // GET: Web
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public PartialViewResult SobreVolutarae()
        {
            return PartialView();
        }

        public ActionResult Departamento()
        {
            return View();
        }

        public ActionResult Voluntario()
        {
            return View();
        }

        public ActionResult Parceiros()
        {
            return View();
        }

        public ActionResult Contatos()
        {
            return View();
        }


    }
}