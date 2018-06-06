﻿using System;
using System.Collections.Generic;

namespace Neptuno.Data.EFEntities
{
    public partial class Empleado : BaseEntity<int>
    {
        public Empleado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Tratamiento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string CodPostal { get; set; }
        public string Pais { get; set; }
        public string TelDomicilio { get; set; }
        public string Extension { get; set; }
        public string Foto { get; set; }
        public string Notas { get; set; }
        public int? Jefe { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
