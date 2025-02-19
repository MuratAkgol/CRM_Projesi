using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        public List<Orders> OrderId { get; set; }
        public List<Products> ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
