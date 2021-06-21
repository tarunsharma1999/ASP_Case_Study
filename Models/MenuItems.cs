using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruYum_Asp.Models
{
    public class MenuItems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,999)]
        public float Price { get; set; }

        public bool isActive { get; set; }

        [Display(Name ="Free Delivery")]
        public bool FreeDelivery { get; set; }

        [Display(Name ="Date of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime DateOfLaunch { get; set; }

       

        public Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }


    }
}