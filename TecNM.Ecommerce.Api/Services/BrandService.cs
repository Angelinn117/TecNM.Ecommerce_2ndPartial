using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Api.Services.Interfaces;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Services;

public class BrandService : IBrandService
{

    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    public async Task<BrandDto> SaveAsync(BrandDto brandDto)
    {
        var brand = new Brand
        {
            Name = brandDto.Name,
            Description = brandDto.Description,
            CountryOrigin = brandDto.CountryOrigin,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdateBy = "",
            UpdateDate = DateTime.Now
        };

        brand = await _brandRepository.SaveAsync(brand);
        brand.Id = brand.Id;

        return brandDto;
    }

    public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
    {
        var brand = await _brandRepository.GetById(brandDto.Id);

        if (brand == null)
            throw new Exception("Brand Not Found");
        brand.Name = brandDto.Name;
        brand.Description = brandDto.Description;
        brand.CountryOrigin = brandDto.CountryOrigin;
        brand.UpdateBy = "";
        brand.UpdateDate = DateTime.Now;
        await _brandRepository.UpdateAsync(brand);

        return brandDto;
    }

    public async Task<List<BrandDto>> GetAllAsync()
    {
        var brands = await _brandRepository.GetAllAsync();
        var brandsDto =
            brands.Select(c => new BrandDto(c)).ToList();
        return brandsDto;
        
    }

    public async Task<bool> BrandExist(int id)
    {
        var brand = await _brandRepository.GetById(id);
        return (brand != null);
    }

    public async Task<BrandDto> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand == null)
            throw new Exception("Brand Not Found");
        var brandDto = new BrandDto(brand);
        return brandDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _brandRepository.DeleteAsync(id);
    }
    
}