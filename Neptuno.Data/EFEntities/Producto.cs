﻿using System;
using System.Collections.Generic;

namespace Neptuno.Data
{
    public partial class Producto
    {
        public Producto()
        {
            LineaPedido = new HashSet<LineaPedido>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdCategoria { get; set; }
        public string CantidadPorUnidad { get; set; }
        public decimal? PrecioUnidad { get; set; }
        public short? UnidadesEnExistencia { get; set; }
        public short? UnidadesEnPedido { get; set; }
        public int? NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Proveedor IdProveedorNavigation { get; set; }
        public ICollection<LineaPedido> LineaPedido { get; set; }
    }
}
