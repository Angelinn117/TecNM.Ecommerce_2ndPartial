using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    //metodo para guardar categorias.
    Task<ProductCategory> SaveAsync(ProductCategory category);
    
    //metodo para actualizar las categorias.
    Task<ProductCategory> UpdateAsync(ProductCategory category);
    
    //Metodo para retornar una lista de categorias.
    Task<List<ProductCategory>> GetAllAsync();
    
    //Metodo para retornar el id de las categoria que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id.
    Task<ProductCategory> GetById(int id);
}