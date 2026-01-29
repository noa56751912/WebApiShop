using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.Models;


namespace Repository
{
    public class RatingRepository:IRatingRepository
    {
        private readonly ApiShopContext _context;
        public RatingRepository(ApiShopContext context)
        {
            _context = context;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            return rating;
        }
    }
}
