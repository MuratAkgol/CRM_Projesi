using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Checks
    {
        [Key]
        public int CheckId { get; set; }
        public int ReceiptId { get; set; }
        public int Maturity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CheckBank { get; set; }
        public string CheckBranch { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public float AccountNumber { get; set; }
        public float CheckNumber { get; set; }
        public float Amount { get; set; }
        public int SupplierId { get; set; }
        public Suppliers Supplier { get; set; }
    }
}
