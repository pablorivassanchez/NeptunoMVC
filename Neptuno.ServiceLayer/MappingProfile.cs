using AutoMapper;
using Neptuno.Domain.Entities;
using Neptuno.ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.ServiceLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(dest=>dest.Proveedor, 
                opt => opt.MapFrom(src => src.ProveedorEnt != null ? src.ProveedorEnt.NombreCompania : string.Empty))
                .ForMember(dest => dest.Categoria,
                opt => opt.MapFrom(src => src.CategoriaEnt != null ? src.CategoriaEnt.NombreCategoria : string.Empty))
                .ReverseMap();
        }
    }
}
