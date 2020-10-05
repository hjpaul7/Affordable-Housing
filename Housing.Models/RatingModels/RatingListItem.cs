using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Models.RatingModels
{
    public class RatingListItem
    {
        [Display(Name = "Housing ID")]
        public int HousingId { get; set; }

        [Display(Name = "User")]
        public string ApplicantId { get; set; }

        [Display(Name = "Rating")]
        public decimal Rating { get; set; }
    }
}
