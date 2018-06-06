using System;
using System.Collections.Generic;

namespace Neptuno.Data.EFEntities
{
    public partial class LineaPedido : BaseEntity<int>
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public short Cantidad { get; set; }
        public float Descuento { get; set; }

        public Pedido IdPedidoNavigation { get; set; }
        public Producto IdProductoNavigation { get; set; }
    }
}
