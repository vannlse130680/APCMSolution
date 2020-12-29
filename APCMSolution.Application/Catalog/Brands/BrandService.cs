using APCMSolution.Data.EF;
using APCMSolution.Data.Models;
using APCMSolution.ViewModel.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APCMSolution.Application.Catalog.Brands
{
    public class BrandService : IBrandService
    {

        private readonly CapstoneProjectContext _context;

        public BrandService(CapstoneProjectContext context)
        {
            _context = context;
        }

        public async Task<int> Create(BrandCreateRequest request)
        {
            var brand = new Brand()
            {
                CompanyId = request.CompanyId,
                Name = request.Name,
                Description = request.Description
            };
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand.Id;
        }
    }
}
