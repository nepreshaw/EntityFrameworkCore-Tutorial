using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial.Models {
    public class Order {
        //primary key
        public int Id { get; set; }
        //telling sql columns what they need based on entity framework
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }
        //link customer that this order is for, link the two together
        public int? CustomerId { get; set; }
        //virtual means it is in the class but not in the table/database
        public virtual Customer Customer { get; set; }

    }
}
