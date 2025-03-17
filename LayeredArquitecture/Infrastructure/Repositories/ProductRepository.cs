using LayeredArquitecture.Domain.Entities;
using LayeredArquitecture.Domain.Interfaces;

public class ProductRepository : IProductRepository
{
  private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 1000 },
        new Product { Id = 2, Name = "Mouse", Price = 50 }
    };

  public IEnumerable<Product> GetAll() => _products;
}
