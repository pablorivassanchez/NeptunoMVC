using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
