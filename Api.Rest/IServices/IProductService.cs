using Api.Rest.Dto;
using Api.Rest.Entities;
using System.Collections.Generic;

namespace Api.Rest.IServices
{
    public interface IProductService
    {
        int Create(ProductDto product);
        object Update(int id,ProductDto dto);
        IEnumerable<Product> GetAll();
        object Delete(int id);
    }
}
