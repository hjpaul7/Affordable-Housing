using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Models.RatingModels
{
   public class RatingCreate
    {
        [Required]
        public decimal Rating { get; set; }
    }
}
