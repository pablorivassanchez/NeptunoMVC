using System;
using System.Collections.Generic;

namespace Neptuno.Domain.Entities
{
    public partial class CompaniaEnvio : BaseEntity<int>
    {
        public CompaniaEnvio()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string NombreCompania { get; set; }
        public string Telefono { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
