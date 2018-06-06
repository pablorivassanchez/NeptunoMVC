using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.EFEntities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public bool Activo { get; set; }
    }
}
