using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using BrandApi.Data;
using BrandApi.Models;

namespace BrandApi.Repository
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly ILogger<BrandsRepository> _logger;
        private readonly ApplicationDbContext _context;

        public BrandsRepository(ILogger<BrandsRepository> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<BrandImages>> GetAllBrands()
        {
            try
            {
                return await _context.Brands.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all brands.");
                throw; 
            }
        }

        public async Task<BrandImages> GetBrandByName(string name)
        {
            try
            {
                return await _context.Brands.SingleOrDefaultAsync(b => b.BrandName == name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the brand by name: {Name}", name);
                throw;
            }
        }
    }
}
