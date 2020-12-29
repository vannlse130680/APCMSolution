using APCMSolution.ViewModel.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APCMSolution.Application.Catalog.Brands
{
    public  interface IBrandService
    {
        Task<int> Create(BrandCreateRequest request);

       
    }
}
