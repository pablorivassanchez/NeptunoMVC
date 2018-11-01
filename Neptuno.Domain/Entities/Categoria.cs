using System.Collections.Generic;

namespace Neptuno.Domain.Entities
{
    public class Categoria : BaseEntity<int>
    {
        public Categoria() : base()
        {
            Productos = new HashSet<Producto>();
        }

        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
