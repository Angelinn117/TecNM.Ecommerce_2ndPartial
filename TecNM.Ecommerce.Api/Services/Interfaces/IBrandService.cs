using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommerce.Api.Services.Interfaces;

public interface IBrandService
{
    //metodo para guardar marcas.
    Task<BrandDto> SaveAsync(BrandDto brand);
    
    //metodo para actualizar las marcas.
    Task<BrandDto> UpdateAsync(BrandDto brand);
    
    //Metodo para retornar una lista de marcas.
    Task<List<BrandDto>> GetAllAsync();
    
    //Metodo para retornar el id de las marcas que borrara.
    Task<bool> BrandExist(int id);
    
    //Metodo para obtener una marca por id.
    Task<BrandDto> GetById(int id);
    
    //Metodo para borrar marcas.
    Task<bool> DeleteAsync(int id);
}