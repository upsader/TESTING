using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESTING.Models
{
    public class Inputs
    {
        [Range(0, 99999)]
        [Required]
        public int Field1 { get; set; }
        [RegularExpression(@"[A-ZŽ]+")]
        [StringLength(3, MinimumLength = 1)]
        [Required]
        public string Field2 { get; set; }
        [RegularExpression(@"[a-z]+")]
        [StringLength(3, MinimumLength = 1)]
        [Required]
        public string Field3 { get; set; }
        [Range(-99999, -1)]
        [Required]
        public int Field4 { get; set; }
        public decimal Sum { get; set; }
        public decimal SumPvn { get; set; }

        public decimal SumTotal { get; set; }

        public string Test { get; set; }
        public string TestPvn { get; set; }


    }
}
