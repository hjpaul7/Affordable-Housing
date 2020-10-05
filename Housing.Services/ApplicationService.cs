using Housing_RedBadgeMVC.Data;
using Housing_RedBadgeMVC.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Services
{
   public class ApplicationService
    {
        private readonly Guid _userId;

        public ApplicationService(Guid userId)
        {
            _userId = userId;
        }

        // Post
        public bool CreateApplication(ApplicationCreate model)
        {
            var entity =
                new Application()
                {
                    HousingId = model.HousingId,
                    ApplicantId = model.ApplicantId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MonthlyIncome = model.MonthlyIncome
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Applications.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        // Get All
        public IEnumerable<ApplicationListItem> GetApplication()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Applications.ToList()
                    .Select(
                        e =>
                        new ApplicationListItem
                        {
                            HousingId = e.HousingId,
                            ApplicantId = e.ApplicantId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            MonthlyIncome = e.MonthlyIncome
                        }
                        );
                return query.ToArray();
            }
        }

        // Get by ID
        public ApplicationDetail GetApplicationDetail(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applications.Single(e => e.Id == id);
                var detailedApplication = new ApplicationDetail
                {
                    HousingId = entity.HousingId,
                    ApplicantId = entity.ApplicantId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    MonthlyIncome = entity.MonthlyIncome
                };
                return detailedApplication;
            }
        }

        // Update
        public bool UpdateApplication(ApplicationUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Applications
                    .Single(e => e.Id == model.Id);

                entity.HousingId = model.HousingId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.MonthlyIncome = model.MonthlyIncome;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteApplication(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applications.Single(e => e.Id == id);
                ctx.Applications.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
