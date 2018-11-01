using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Domain.Entities
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {
            Activo = true;
        }
        public T Id { get; set; }
        public bool Activo { get; set; }
    }
}
