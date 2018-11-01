using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Neptuno.Data;
using Neptuno.Data.Repositories;
using Neptuno.Domain.Entities;
using Neptuno.ServiceLayer.Dto;
using Neptuno.ServiceLayer.Interfaces;

namespace Neptuno.ServiceLayer
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Producto> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IRepository<Producto> repo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ProductoDto GetProduct(int idProduct)
        {
            var retorno = _repo.Get(x=>x.Id == idProduct,q=>q.Include(a=>a.CategoriaEnt).Include(x=>x.ProveedorEnt));

            return mapper.Map<ProductoDto>(retorno);
        }

        public List<ProductoDto> GetProducts()
        {
            var retorno = _repo.GetMany(x=>x.Activo, q=>q.OrderBy(x=>x.Id), q=>q.Include(a=>a.CategoriaEnt).Include(x=>x.ProveedorEnt));

            return mapper.Map<List<ProductoDto>>(retorno);
        }
    }
}
