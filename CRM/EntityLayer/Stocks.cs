using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Stocks
    {
        [Key]
        public int StockId { get; set; }
        public List<Products> ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Location { get; set; }
    }
}
