
using Housing_RedBadgeMVC.Data;
using Housing_RedBadgeMVC.Models.ApplicationModels;
using Housing_RedBadgeMVC.Models.HousingModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Housing_RedBadgeMVC.Services
{
    public class HousingService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userId;

        public HousingService(Guid userId)
        {
            _userId = userId;
        }

        // Post
        public bool CreateHousing(HttpPostedFileBase file, HousingCreate model)
        {
            model.Image = ConvertToBytes(file);

            var entity =
                new Housing()
                {
                    Name = model.Name,
                    Address = model.Address,
                    UnitsAvailable = model.UnitsAvailable,
                    AcceptVoucher = model.AcceptVoucher,
                    SectionType = model.SectionType,
                    Image = model.Image
                };

            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Housings.Add(entity);
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
                    .Housings.ToList()
                    .Select(
                        e =>
                        new HousingListItem
                        {
                            HousingId = e.HousingId,
                            Name = e.Name,
                            Address = e.Address,
                            UnitsAvailable = e.UnitsAvailable,
                            AcceptVoucher = e.AcceptVoucher,
                            SectionType = e.SectionType,
                            IsSafe = e.IsSafe,
                            Image = e.Image
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
                var entity = ctx.Housings.Single(e => e.HousingId == id);
                var detailedHousing = new HousingDetail
                {
                    HousingId = entity.HousingId,
                    Name = entity.Name,
                    Address = entity.Address,
                    UnitsAvailable = entity.UnitsAvailable,
                    AcceptVoucher = entity.AcceptVoucher,
                    SectionType = entity.SectionType,
                    IsSafe = entity.IsSafe,
                    Image = entity.Image
                };
                return detailedHousing;
            }
        }

        // Update
        public int UpdateHousingById(HttpPostedFileBase file, int id, HousingUpdate newHousing)
        {
            newHousing.Image = ConvertToBytes(file);

            using (var ctx = new ApplicationDbContext())
            {
                Housing housing = ctx.Housings.Find(id);
                if (housing == null)
                {
                    return 2;
                }
                housing.Name = newHousing.Name;
                housing.Address = newHousing.Address;
                housing.UnitsAvailable = newHousing.UnitsAvailable;
                housing.AcceptVoucher = newHousing.AcceptVoucher;
                housing.SectionType = newHousing.SectionType;
                housing.Image = newHousing.Image;
                if (ctx.SaveChanges() == 1)
                    return 0;
                return 1;
            }
        }

        public bool UpdateHousing(HttpPostedFileBase file, HousingUpdate model)
        {
            model.Image = ConvertToBytes(file);

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Housings
                    .Single(e => e.HousingId == model.HousingId );
                // && e.OwnerId == _userId

                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.UnitsAvailable = model.UnitsAvailable;
                entity.AcceptVoucher = model.AcceptVoucher;
                entity.SectionType = model.SectionType;
                entity.Image = model.Image;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteHousing(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Housings.Single(e => e.HousingId == id);
                ctx.Housings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        public byte[] GetImageFromDB(int id)
        {
            using (var rvw = new ApplicationDbContext())
            {
                var q = from temp in rvw.Housings where temp.HousingId == id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}
