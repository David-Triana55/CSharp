Person person = new Person();
person.Nombre = "Juan";
person.Edad = 25;
person.Apellido = "Triana";
person.Direccion = new Adrress();
person.Direccion.Calle = "Calle 1";
person.Direccion.Ciudad = "Ciudad 1";

Person Person2 = person.Clone() as Person;
Person2.Nombre = "Pedro";
Person2.Edad = 30;
Person2.Apellido = "Garcia";
Person2.Direccion.Calle = "Calle 2";
Person2.Direccion.Ciudad = "Ciudad 2";


Console.WriteLine($"Nombre: {person.Nombre}");
Console.WriteLine($"Edad: {person.Edad}");
Console.WriteLine($"Apellido: {person.Apellido}");
Console.WriteLine($"Calle: {person.Direccion.Calle}");
Console.WriteLine($"Ciudad: {person.Direccion.Ciudad}");
Console.WriteLine($"---------------------------------");

Console.WriteLine($"Nombre: {Person2.Nombre}");
Console.WriteLine($"Edad: {Person2.Edad}");
Console.WriteLine($"Apellido: {Person2.Apellido}");
Console.WriteLine($"Calle: {Person2.Direccion.Calle}");
Console.WriteLine($"Ciudad: {Person2.Direccion.Ciudad}");
