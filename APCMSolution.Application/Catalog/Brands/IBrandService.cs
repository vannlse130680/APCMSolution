using APCMSolution.Data.Models;
using APCMSolution.ViewModel.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APCMSolution.Application.Catalog.Brands
{
    public  interface IBrandService
    {
        //Task<int> Create(BrandCreateRequest request);
        //Task<int> Update(BrandUpdateRequest request);
        //Task<int> Delete(int brandId);
        Task<List<Data.Models.Brand>> GetAll();
         
    }
}

