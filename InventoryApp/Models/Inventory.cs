using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Inventory
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public string Sku { get; set; }

        public int Qty { get; set; }

        [DisplayName("Picture")]
        public string PictureUrl { get; set; }

        //[Range(0, 999)]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Manufacture { get; set; }

        public int NumReview { get; set; }

        public decimal Rating { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }


        public virtual Store Stores { get; set; }
    }
}