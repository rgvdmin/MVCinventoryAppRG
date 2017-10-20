using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryApp.ViewModels
{
    public class InventoryViewModel
    {
        
        public string Name { get; set; }

        [DisplayName("Photo")]
        public string PictureUrl { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public int NumReview { get; set; }

        public string Manufacture { get; set; }

        public string Description { get; set; }

        public string StoreName { get; set; }


    }
}