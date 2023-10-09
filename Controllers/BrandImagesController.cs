using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrandApi.Data;
using BrandApi.Models;
using BrandApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace BrandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandImagesController : ControllerBase
    {
        private readonly ILogger<BrandImagesController> _logger; 
        private readonly IBrandsRepository _brands;

        public BrandImagesController(ILogger<BrandImagesController> logger, IBrandsRepository brands) 
        {
            _logger = logger;
            _brands = brands;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<BrandImages>>> GetBrands()
        {
            try
            {
                var brands = await _brands.GetAllBrands();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all brands.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the data.");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<BrandImages>> GetBrandImages(string name)
        {
            try
            {
                var brand = await _brands.GetBrandByName(name);

                if (brand != null)
                {
                    return Ok(brand);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching brand by name: {Name}", name);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the data.");
            }
        }
    }
}
