using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APCMSolution.Application.Catalog.Brands;
using APCMSolution.Data.UnitOfWorks;
using APCMSolution.ViewModel.Catalog.Brands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APCMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        //private readonly IBrandService _brandService;



        //public BrandController(IBrandService brandService)
        //{
        //    _brandService = brandService;
        //}




        // create a new brand
        //[HttpPost]
        //public async Task<IActionResult> Create(BrandCreateRequest request) //phuog
        //{

        //    var brandId = await _brandService.Create(request);
        //    if (brandId == 0)
        //    {
        //        return BadRequest(); //400
        //    }
        //    return Ok();

        //}


        //update brand
        //[HttpPut]
        //public async Task<IActionResult> Update(BrandUpdateRequest request)
        //{
        //    var brandId = await _brandService.Update(request);
        //    if (brandId == 0)
        //    {
        //        return BadRequest(); //400
        //    }
        //    return Ok();
        //}


        //delete brand
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int brandId)
        //{
        //    int id = await _brandService.Delete(brandId);
        //    if (id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}


        private readonly IBrandService _brandServices;
        public BrandController(IBrandService brandServices)
        {
            _brandServices = brandServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetBrand()
        {
            var result = await _brandServices.GetAll();
            return Ok(JsonConvert.SerializeObject(result));
        }




    }
}
