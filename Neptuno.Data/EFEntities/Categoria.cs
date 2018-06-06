using System.Collections.Generic;

namespace Neptuno.Data.EFEntities
{
    public partial class Categoria : BaseEntity<int>
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
