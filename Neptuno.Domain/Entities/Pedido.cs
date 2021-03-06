﻿using System;
using System.Collections.Generic;

namespace Neptuno.Domain.Entities
{
    public class Pedido : BaseEntity<int>
    {
        public Pedido() : base()
        {
            LineasPedido = new HashSet<LineaPedido>();
        }

        public string IdCliente { get; set; }
        public int? IdEmpleado { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public int? FormaEnvio { get; set; }
        public decimal? Cargo { get; set; }
        public string Destinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string CiudadDestinatario { get; set; }
        public string RegionDestinatario { get; set; }
        public string CodPostalDestinatario { get; set; }
        public string PaisDestinatario { get; set; }

        public CompaniaEnvio CompaniaEnvioEnt { get; set; }
        public Cliente ClienteEnt { get; set; }
        public Empleado EmpleadoEnt { get; set; }
        public ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
