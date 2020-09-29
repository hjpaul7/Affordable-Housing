using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Housing_RedBadgeMVC.Data.Housing;

namespace Housing_RedBadgeMVC.Models
{
    public class HousingUpdate
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int UnitsAvailable { get; set; }

        public Voucher AcceptVoucher { get; set; }

        public Section SectionType { get; set; }
    }
}
