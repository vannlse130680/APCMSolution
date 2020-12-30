using APCMSolution.Data.EF;
using APCMSolution.Data.Models;
using APCMSolution.Data.UnitOfWorks;
using APCMSolution.ViewModel.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APCMSolution.Application.Catalog.Brands
{
    public class BrandService : IBrandService
    {

        //private readonly CapstoneProjectContext _context;

        //public BrandService(CapstoneProjectContext context)
        //{
        //    _context = context;
        //}

        //public BrandService(CapstoneProjectContext context)
        //{
        //    _context = context;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       


        //public async Task<int> Create(BrandCreateRequest request)
        //{
        //    var brand = new Brand()
        //    {
        //        CompanyId = request.CompanyId,
        //        Name = request.Name,
        //        Description = request.Description
        //    };
        //    _context.Brands.Add(brand);
        //    await _context.SaveChangesAsync();
        //    return brand.Id;
        //}

        //public async Task<int> Delete(int brandId)
        //{
        //    var brand = await _context.Brands.FindAsync(brandId);
        //    if (brand == null) throw new Exception($" Can not find a product with id: {brandId}");
        //    _context.Brands.Remove(brand);
        //    await _context.SaveChangesAsync();
        //    return brand.Id;
        //}

        public async Task<List<Data.Models.Brand>> GetAll()
        {
            var brand = _unitOfWork.Repository<Data.Models.Brand>().GetAll().AsQueryable();
            List<Data.Models.Brand> listBrand = new List<Data.Models.Brand>();
            foreach (var item in brand)
            {
                Data.Models.Brand brandObj = new Data.Models.Brand()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                listBrand.Add(brandObj);
            }
            return listBrand;
        }

       
        //public async Task<int> Update(BrandUpdateRequest request)
        //{
        //    var brand = await _context.Brands.FindAsync(request.Id);
        //    if (brand == null) throw new Exception($" Can not find a product with id: {request.Id}");
        //    brand.CompanyId = request.CompanyId;
        //    brand.Name = request.Name;
        //    brand.Description = request.Description;

        //    await _context.SaveChangesAsync();
        //    return brand.Id;
        //}
    }
}
