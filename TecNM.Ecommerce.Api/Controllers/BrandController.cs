using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<BrandDto>>>> GetAll()
    {
        var response = new Response<List<BrandDto>>
        {
            Data = await _brandService.GetAllAsync()
        };
        
        
        /*var brands = await _brandRepository.GetAllAsync();
        response.Data = brands.Select(c => new BrandDto(c)).ToList();*/

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<BrandDto>>> Post([FromBody] BrandDto brandDto)
    {
        var response = new Response<BrandDto>()
        {
            Data = await _brandService.SaveAsync(brandDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BrandDto>>> GetById(int id)
    {
        var response = new Response<BrandDto>();
        
        if (!await _brandService.BrandExist(id))
        {
            response.Errors.Add("Brand Not Found");
            return NotFound(response);
        }
        
        response.Data = await _brandService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BrandDto>>> Update(int id, [FromBody] BrandDto brandDto)
    {
        var response = new Response<BrandDto>();
        
        if (!await _brandService.BrandExist(brandDto.Id))
            //if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Brand Not Found");
            return NotFound(response);
        }
        
        response.Data = await _brandService.UpdateAsync(brandDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _brandService.DeleteAsync(id);
        
        return Ok(response);
    }
}