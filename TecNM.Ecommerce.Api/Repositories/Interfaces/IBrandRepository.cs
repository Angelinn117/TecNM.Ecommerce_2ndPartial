using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces;

public interface IBrandRepository
{
    //metodo para guardar marcas.
    Task<Brand> SaveAsync(Brand brand);
    
    //metodo para actualizar las marcas.
    Task<Brand> UpdateAsync(Brand brand);
    
    //Metodo para retornar una lista de marcas.
    Task<List<Brand>> GetAllAsync();
    
    //Metodo para retornar el id de las marca que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una marca por id.
    Task<Brand> GetById(int id);
}