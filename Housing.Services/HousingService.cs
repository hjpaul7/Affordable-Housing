
using Housing_RedBadgeMVC.Data;
using Housing_RedBadgeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_RedBadgeMVC.Services
{
    public class HousingService
    {
        private readonly Guid _userId;

        public HousingService(Guid userId)
        {
            _userId = userId;
        }

        // Post
        public bool CreateHousing(HousingCreate housing)
        {
            var entity =
                new Housing()
                {
                    Name = housing.Name,
                    Address = housing.Address,
                    UnitsAvailable = housing.UnitsAvailable,
                    AcceptVoucher = housing.AcceptVoucher,
                    SectionType = housing.SectionType
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Housing.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get all
        public IEnumerable<HousingListItem> GetHousing()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Housing.ToList()
                    .Select(
                        e =>
                        new HousingListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Address = e.Address,
                            UnitsAvailable = e.UnitsAvailable,
                            AcceptVoucher = e.AcceptVoucher,
                            SectionType = e.SectionType
                        }
                        );
                return query.ToArray(); 
            }
        }

        // Get Housing by ID
        public HousingDetail GetHousingDetail(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Housing.Single(e => e.Id == id);
                var detailedHousing = new HousingDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Address = entity.Address,
                    UnitsAvailable = entity.UnitsAvailable,
                    AcceptVoucher = entity.AcceptVoucher,
                    SectionType = entity.SectionType
                };
                return detailedHousing;
            }
        }

        // Update
        public int UpdateHousingById(int id, HousingUpdate newHousing)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Housing housing = ctx.Housing.Find(id);
                if (housing == null)
                {
                    return 2;
                }
                housing.Name = newHousing.Name;
                housing.Address = newHousing.Address;
                housing.UnitsAvailable = newHousing.UnitsAvailable;
                housing.AcceptVoucher = newHousing.AcceptVoucher;
                housing.SectionType = newHousing.SectionType;
                if (ctx.SaveChanges() == 1)
                    return 0;
                return 1;
            }
        }

        // Delete
        public bool DeleteHousing(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Housing.Single(e => e.Id == id);
                ctx.Housing.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
