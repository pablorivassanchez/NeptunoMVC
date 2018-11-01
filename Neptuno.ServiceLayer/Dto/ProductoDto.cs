using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.ServiceLayer.Dto
{
    public class ProductoDto
    {
        public string NombreProducto { get; set; }
        public string Proveedor { get; set; }
        public string Categoria { get; set; }
        public string CantidadPorUnidad { get; set; }
        public decimal? PrecioUnidad { get; set; }
        public short? UnidadesEnExistencia { get; set; }
        public short? UnidadesEnPedido { get; set; }
        public int? NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }
    }
}
