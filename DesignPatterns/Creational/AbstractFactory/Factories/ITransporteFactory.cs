using AbstractFactory.Models;
namespace AbstractFactory.Factories;

public interface ITransporteFactory
{
  ICarro CrearCarro();
  IMoto CrearMoto();
}
