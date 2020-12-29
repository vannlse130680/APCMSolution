using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APCMSolution.Application.Catalog.Brands;
using APCMSolution.ViewModel.Catalog.Brands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APCMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        // create a new brand
        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateRequest request) //phuog
        {

            var brandId = await _brandService.Create(request);
            if (brandId == 0)
            {
                return BadRequest(); //400
            }
            return Ok();
            //return Created(nameof(GetById), productId);

        }
    }
}
