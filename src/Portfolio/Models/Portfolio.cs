using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    [Table("Portfolio")]
    public class Portfolio
    {
        [Key]
        public string Body { get; set; }
        public string User { get; set; }
    }
}
