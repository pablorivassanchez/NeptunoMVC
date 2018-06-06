using Neptuno.Data;
using Neptuno.Data.EFEntities;
using Neptuno.Data.Repositories;

namespace Neptuno.ServiceLayer
{
    public class ProductService
    {
        private readonly IRepository<Producto> _repo;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IRepository<Producto> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }
    }
}
