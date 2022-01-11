using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppKuspyKreme.Models
{
    public class CouponEstablisment
    {
        public Coupon Coupon { get; set; }  
        public List<SelectListItem> ListEstablishments { get; set; }
        public List<SelectListItem> ListEstatus { get; set; }
    }
}