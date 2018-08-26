using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoluntarAe.Web.Models
{
    public class CategoryBindingViewModels
    {
        public int id { get; set; }
        public String title { get; set; }
        public List<DetailsBindingViewModels> detailsList = new List<DetailsBindingViewModels>();
    }
}