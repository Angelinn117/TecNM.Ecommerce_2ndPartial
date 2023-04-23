using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IProductCategoryService
{
    //metodo para guardar categorias.
    Task<ProductCategoryDto> SaveAsync(ProductCategoryDto category);
    
    //metodo para actualizar las categorias.
    Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto category);
    
    //Metodo para retornar una lista de categorias.
    Task<List<ProductCategoryDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categoria que borrara.
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id.
    Task<ProductCategoryDto> GetById(int id);
    
    //Metodo para borrar.
    Task<bool> DeleteAsync(int id);
}