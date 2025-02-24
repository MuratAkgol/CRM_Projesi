using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SupplierGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<Suppliers> Suppliers { get; set; }

    }
}
