using System;
using System.Collections.Generic;

namespace Neptuno.Data
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
