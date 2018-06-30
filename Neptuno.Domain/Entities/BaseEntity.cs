using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Domain.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public bool Activo { get; set; }
    }
}
