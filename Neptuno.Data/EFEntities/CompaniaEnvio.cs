using System;
using System.Collections.Generic;

namespace Neptuno.Data
{
    public partial class CompaniaEnvio
    {
        public CompaniaEnvio()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdCompaniaEnvio { get; set; }
        public string NombreCompania { get; set; }
        public string Telefono { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
