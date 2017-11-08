using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Opening Date")]
        public DateTime OpenDate { get; set; }

        
        public TimeSpan Open { get; set; }

        public TimeSpan Close { get; set; }

        [Range(0, 5)]
        [Required]
        public int Rating { get; set; }

        public int CategoryID { get; set; } 

        [ForeignKey("CategoryID")]
        public virtual StoreCategory Category { get; set; }
    }
}