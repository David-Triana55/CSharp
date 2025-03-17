using LayeredArquitecture.Domain.Entities;

namespace LayeredArquitecture.Domain.Interfaces;
public interface IProductRepository
{
  IEnumerable<Product> GetAll();
}
