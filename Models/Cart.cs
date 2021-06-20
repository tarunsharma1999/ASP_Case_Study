using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TruYum_Asp.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }

        public MenuItems MenuItem { get; set; }

        public Cart() { }
    }
}