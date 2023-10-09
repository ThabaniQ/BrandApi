using BrandApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandApi.Repository
{
    public interface IBrandsRepository
    {
        Task<IEnumerable<BrandImages>> GetAllBrands();
        Task<BrandImages> GetBrandByName(string name);
    }
}
