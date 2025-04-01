using AbstractFactory.Factories;
using AbstractFactory.Models;



// Crear una fábrica de vehículos de combustión
ITransporteFactory combustionFactory = new CombustionFactory();
ICarro carroCombustion = combustionFactory.CrearCarro();
IMoto motoCombustion = combustionFactory.CrearMoto();

carroCombustion.Encender();
motoCombustion.Acelerar();

// Crear una fábrica de vehículos eléctricos
ITransporteFactory electricoFactory = new ElectricoFactory();
ICarro carroElectrico = electricoFactory.CrearCarro();
IMoto motoElectrica = electricoFactory.CrearMoto();

carroElectrico.Encender();
motoElectrica.Acelerar();


