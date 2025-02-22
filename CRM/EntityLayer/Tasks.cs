using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string? TaskContent { get; set; }
        public int TaskOwnerId { get; set; }
        public string TaskStatus { get; set; }
        public DateTime? TaskCreatedDate { get; set; } = DateTime.Now;
        public int TaskCreatorId { get; set; }
        public Users TaskCreator { get; set; }
    }
}
