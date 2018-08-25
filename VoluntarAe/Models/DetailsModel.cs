using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.API.Models
{
    public class DetailsModel
    {
        public int id { get; set; }
        public String title { get; set; }
        public String subTitle { get; set; }
        public String date { get; set; }
        public String image { get; set; }
        public String hour { get; set; }
        public String place { get; set; }
        public String description { get; set; }
        public String tags { get; set; }
        public String youtube { get; set; }
        public String organizer { get; set; }
        public String phone { get; set; }
        public int categoryId { get; set; }
        public String categoryName { get; set; }
    }
}