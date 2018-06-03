using System.Buffers.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neptuno.Data;

namespace Neptuno.Test
{
    [TestClass]
    public class CreatingDataBase
    {
        [TestMethod]
        public void CreatingDataBaseEstructure()
        {
            using (NeptunoContext context = new NeptunoContext())
            {
                DbInitializer.Initialize(context);
            }
        }
    }
}
