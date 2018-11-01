using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neptuno.Data.Configurations;
using Neptuno.Domain.Entities;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Extensions.Logging;

namespace Neptuno.Data
{
    public partial class NeptunoContext : DbContext, IDbContext, IUnitOfWork
    {
        public NeptunoContext()
        {

            Log.Logger = new LoggerConfiguration()
                        .WriteTo.File(@"myapp\log.txt")
                        .CreateLogger();
            _loggerFactory = new LoggerFactory(new[] { new SerilogLoggerProvider(Log.Logger) }); //(category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information,true)
        }
        private readonly ILoggerFactory _loggerFactory;
        public NeptunoContext(DbContextOptions<NeptunoContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<CompaniaEnvio> CompaniaEnvio { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<LineaPedido> LineaPedido { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(_loggerFactory)
                    .UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=Neptuno;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new CompaniaEnvioConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
            modelBuilder.ApplyConfiguration(new LineaPedidoConfig());
            modelBuilder.ApplyConfiguration(new PedidoConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new ProveedorConfig());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
