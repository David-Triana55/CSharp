using LayeredArquitecture.Domain.Entities;
using LayeredArquitecture.Domain.Interfaces;
namespace LayeredArquitecture.Application.Services;

public class ProductService
{
  private readonly IProductRepository _repository;

  public ProductService(IProductRepository repository)
  {
    _repository = repository;
  }

  public IEnumerable<Product> GetAllProducts()
  {
    return _repository.GetAll();
  }
}
