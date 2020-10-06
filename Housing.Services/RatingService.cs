using Housing_RedBadgeMVC.Data;
using Housing_RedBadgeMVC.Models.RatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_RedBadgeMVC.Services
{
   public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        // Post
        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new SafetyRating()
                {
                    HousingId = model.HousingId,
                    ApplicantId = model.ApplicantId,
                    Rating = model.Rating
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SafetyRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All
        public IEnumerable<RatingListItem> GetRating()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SafetyRatings.ToList()
                    .Select(
                        e =>
                        new RatingListItem
                        {
                            HousingId = e.HousingId,
                            ApplicantId = e.ApplicantId,
                            Rating = e.Rating
                        }
                        );
                return query.ToArray();
            }
        }

        public RatingDetail GetRatingDetail(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.SafetyRatings.Single(e => e.Id == id);
                var detailedRating = new RatingDetail
                {
                    HousingId = entity.HousingId,
                    ApplicantId = entity.ApplicantId,
                    Rating = entity.Rating
                };
                return detailedRating;
            }
        }


        // Update
        public bool UpdateRating(RatingUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SafetyRatings
                    .Single(e => e.Id == model.Id);

                entity.Rating = model.Rating;

                return ctx.SaveChanges() == 1;
            }
        }


        // Delete
        public bool DeleteRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.SafetyRatings.Single(e => e.Id == id);
                ctx.SafetyRatings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
