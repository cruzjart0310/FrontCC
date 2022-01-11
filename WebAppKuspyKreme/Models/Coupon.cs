using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAppKuspyKreme.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Duration required")]
        [Display(Prompt ="YYYY/MM/DD")]
        public string Duration { get; set; }

        public Status Status { get; set; }
        public Establishment Establishment { get; set; }

        //[ReadOnly(true)]
        [Required(ErrorMessage = "Serie required")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
    }
}