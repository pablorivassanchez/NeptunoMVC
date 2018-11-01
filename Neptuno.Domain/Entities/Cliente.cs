using System;
using System.Collections.Generic;

namespace Neptuno.Domain.Entities
{
    public class Cliente : BaseEntity<string>
    {
        public Cliente() : base()
        {
            Pedidos = new HashSet<Pedido>();
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

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
