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
        public int HousingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int UnitsAvailable { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

        public virtual ICollection<SafetyRating> Ratings { get; set; } = new List<SafetyRating>();

        

        

        [Required]
        public Voucher AcceptVoucher { get; set; }

        // need to remove set and change logic for get
        //public bool IsSafe { get
        //    {
        //        var averageRating = Ratings.Average(r => r.Rating);

        //        if (averageRating >= 5)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        public bool IsSafe => Ratings.Select(r => r.Rating).DefaultIfEmpty(0).Average() >= 5;



        [Required]
        public Section SectionType { get; set; }

        public byte[] Image { get; set; }



        public enum Section {
            [Display(Name = "Section 8")]
            Section8, 
            [Display(Name = "Section 42")]
            Section42 }
        public enum Voucher { Yes, No, Unsure }
    }
}
