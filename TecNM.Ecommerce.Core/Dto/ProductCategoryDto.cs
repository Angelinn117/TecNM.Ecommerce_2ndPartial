using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Core.Dto;

public class ProductCategoryDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ProductCategoryDto()
    {
        
    }

    public ProductCategoryDto(ProductCategory category)
    {
        Name = category.Name;
        Description = category.Description;
        Id = category.Id;
    }
}