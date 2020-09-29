using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_RedBadgeMVC.Data
{
    public class Housing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int UnitsAvailable { get; set; }

        [Required]
        public Voucher AcceptVoucher { get; set; }

        // need to remove set and change logic for get
        public bool IsSafe { get; set; }


        [Required]
        public Section SectionType { get; set; }



        public enum Section { Section8, Section42 }
        public enum Voucher { Yes, No }
    }
}
