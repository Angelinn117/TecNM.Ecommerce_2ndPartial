using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    //private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IProductCategoryService _productCategoryService;

    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ProductCategoryDto>>>> GetAll()
    {
        var response = new Response<List<ProductCategoryDto>>
        {
            Data = await _productCategoryService.GetAllAsync()
        };
        
        /*var categories = await _productCategoryRepository.GetAllAsync();
        response.Data = categories.Select(c => new ProductCategoryDto(c)).ToList();*/

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>()
        {
            Data = await _productCategoryService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetById(int id)
    {
        var response = new Response<ProductCategoryDto>();
        
        if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }
        
        response.Data = await _productCategoryService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Update(int id,[FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>();
        
       if (!await _productCategoryService.ProductCategoryExist(categoryDto.Id))
        //if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }
       
        response.Data = await _productCategoryService.UpdateAsync(categoryDto);

        return Ok(response);
        
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _productCategoryService.DeleteAsync(id);
        response.Data = result;
        // var response = new Response<bool>{Data = false};
        // response.Data = category;
        return Ok(response);
    }
}