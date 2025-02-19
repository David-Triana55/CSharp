using POO;
using POO.Models;
ImprimirInfo imprimirInfo = new ImprimirInfo();

SuperPoder poderVolar = new SuperPoder("Volar", "Capacidad de volar y planear", NivelPoder.NivelDos);
SuperPoder visionRayosX = new SuperPoder("Visión de Rayos X", "Capacidad de ver a través de objetos sólidos", NivelPoder.NivelCuatro);
SuperPoder regeneracion = new SuperPoder("Regeneracion", "Capacidad para regenerarse", NivelPoder.NivelCinco);

var superman = new SuperHeroe(1, "Superman", "Clarck kent", "Metropolis", new List<SuperPoder> { poderVolar, visionRayosX }, true);
var batman = new SuperHeroe(2, "Batman", "Bruce Wayne", "Gotica", new List<SuperPoder> { poderVolar }, false);

batman.MostrarInfomacion();
superman.MostrarInfomacion();

AntiHeroe wolverine = new AntiHeroe(3, "Wolverine", "Logan", "desconocida", new List<SuperPoder> { regeneracion }, false, "Atacar polica");
wolverine.MostrarInfomacion();
wolverine.AccionAntiHeroe();

superman.SalvarMundo();

imprimirInfo.ImprimirSuperHeroe(superman);

enum NivelPoder //manejo de valores implicitos.
{
  NivelUno,
  NivelDos,
  NivelTres,
  NivelCuatro,
  NivelCinco,
  NivelSeis,
  NivelSiete,
  NivelOcho,
  NivelNueve,
  NivelDiez
}