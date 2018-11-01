using Neptuno.ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.ServiceLayer.Interfaces
{
    public interface IProductService
    {
        List<ProductoDto> GetProducts();
        ProductoDto GetProduct(int idProduct);
    }
}
