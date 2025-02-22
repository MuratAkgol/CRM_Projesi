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
        public string Name { get; set; }
        public string ContactMail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCity { get; set; }
        public DateTime LastOperation { get; set; }
        public bool IsActive { get; set; }
    }
}
