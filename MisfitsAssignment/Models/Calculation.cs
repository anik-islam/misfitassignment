using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MisfitsAssignment.Models
{
    public class Calculation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Value_1 { get; set; }
        public string Value_2 { get; set; }
        public string Result { get; set; }
        public DateTime EntryDate { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
