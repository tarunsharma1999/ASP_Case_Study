using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYum_Asp.Models
{
    public class Category
    {
        [Key]
        public  int Id { get; set; }

        public string Name { get; set; }
    }
}