using System;
using System.Collections.Generic;

namespace Neptuno.Domain.Entities
{
    public class Proveedor : BaseEntity<int>
    {
        public Proveedor() : base()
        {
            Productos = new HashSet<Producto>();
        }

        public string NombreCompania { get; set; }
        public string NombreContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string CodPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string PaginaPrincipal { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
