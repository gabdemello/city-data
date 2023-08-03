﻿using CityDataAPI.DbContexts;
using CityDataAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityDataAPI.Services
{
    public class CityDataRepository : ICityDataRepository
    {
        private readonly CityDataContext _context;
        public CityDataRepository(CityDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            if(includePointsOfInterest)
            {
                return await _context.Cities.Include(c => c.PointOfInterests)
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }

            return await _context.Cities
                .Where(c => c.Id == cityId) .FirstOrDefaultAsync();
        }

        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(
            int cityId,
            int pointOfInterestId)
        {
            return await _context.PointsOfInterest
               .Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestsForCityAsync(int cityId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityId)
                .ToListAsync();
        }
    }
}