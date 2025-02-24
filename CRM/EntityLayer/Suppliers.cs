using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string CompanyName { get; set; }
        public string? CompanyTitle { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; } 
        public Users User { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public int SupplierGroupId { get; set; }
        public SupplierGroup SupplierGroup { get; set; }
    }
}
