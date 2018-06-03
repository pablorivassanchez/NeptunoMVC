using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Neptuno.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NeptunoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pedido.Any())
            {
                return;   // DB has been seeded
            }

            var sql = System.IO.File.ReadAllText("seed.sql", System.Text.Encoding.UTF8);

            context.Database.ExecuteSqlCommand(sql);
        }
    }
}
