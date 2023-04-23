using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Core.Dto;

public class BrandDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CountryOrigin { get; set; }


    public BrandDto()
    {
        
    }

    public BrandDto(Brand brand)
    {
        Name = brand.Name;
        Description = brand.Description;
        CountryOrigin = brand.CountryOrigin;
        Id = brand.Id;
    }
    
}