
AutorRepository autoresRepository = new();

LibroRepository librosRepository = new();

PrestamoRepository prestamosLibrosRepository = new(autoresRepository, librosRepository);


Console.WriteLine("Bienvenido");
int menu = 0;

while (menu != 4)
{
  Console.WriteLine("1. Gestrionar Libros");
  Console.WriteLine("2. Gestionar Autores");
  Console.WriteLine("3. Gestionar Prestamos");
  Console.WriteLine("4. Salir\n");
  Console.Write("Opción: ");
  menu = int.Parse(Console.ReadLine());
  Console.WriteLine();

  switch (menu)
  {
    case 1:
      int opcionLibro = 0;
      while (opcionLibro != 5)
      {
        Console.WriteLine("1. Obtener la lista de los libros");
        Console.WriteLine("2. Agregar Libro");
        Console.WriteLine("3. Editar Libro");
        Console.WriteLine("4. Eliminar Libro");
        Console.WriteLine("5. Salir");
        Console.Write("Opción: ");

        opcionLibro = int.Parse(Console.ReadLine());
        Console.WriteLine();
        switch (opcionLibro)
        {
          case 1:
            List<Libro> listaLibros = librosRepository.ObtenerLibros();
            for (var i = 0; i < listaLibros.Count; i++)
            {
              Console.WriteLine($"Indice: {i + 1}");
              Console.WriteLine($"Titulo: {listaLibros[i].Titulo}");
              Console.WriteLine($"Autor: {listaLibros[i].Autor}");
              Console.WriteLine($"Genero: {listaLibros[i].Genero}");
              Console.WriteLine($"Fecha de publicación: {listaLibros[i].FechaPublicacion.ToShortDateString()}");
              Console.WriteLine($"Estado: {listaLibros[i].Estado}");
              Console.WriteLine("---------------------------------------");
            }
            break;

          case 2:
            Console.Write("Titulo: ");
            string agregarTitulo = Console.ReadLine();

            Console.Write("Autor: ");
            string agregarAutor = Console.ReadLine();

            Console.Write("Genero: ");
            string agregarGenero = Console.ReadLine();

            Console.Write("Fecha de publicación: ");
            DateTime agregarFechaPublicacion = DateTime.Parse(Console.ReadLine());

            Libro agregarLibro = new(agregarTitulo, agregarAutor, agregarGenero, agregarFechaPublicacion);
            librosRepository.AgregarLibro(agregarLibro);
            Console.WriteLine("Libro Agregado con éxito");
            Console.WriteLine();
            break;

          case 3:
            Console.Write("Escriba el numero del indice del libro a Editar: ");
            int indiceEditar = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Titulo: ");
            string editarTitulo = Console.ReadLine();
            Console.Write("Autor: ");
            string editarAutor = Console.ReadLine();
            Console.Write("Genero: ");
            string editarGenero = Console.ReadLine();
            Console.Write("Fecha de publicación: ");
            DateTime editarFechaPublicacion = DateTime.Parse(Console.ReadLine());

            Libro editarLibro = new(editarTitulo, editarAutor, editarGenero, editarFechaPublicacion);
            librosRepository.EditarLibro(indiceEditar, editarLibro);
            Console.WriteLine("Libro Editado con éxito");
            Console.WriteLine();
            break;

          case 4:
            Console.Write("Escriba el numero del indice del libro a Eliminar: ");
            int indiceEliminar = int.Parse(Console.ReadLine()) - 1;
            librosRepository.EliminarLibro(indiceEliminar);
            Console.WriteLine("Libro Eliminado con éxito");
            Console.WriteLine();
            break;

          case 5:
            Console.WriteLine("Saliendo");
            break;

          default:
            Console.WriteLine("Opción no válida");
            break;
        }
      }

      break;
    case 2:
      int opcionAutor = 0;
      while (opcionAutor != 5)
      {
        Console.WriteLine("1. Obtener la lista de los Autores");
        Console.WriteLine("2. Agregar Autor");
        Console.WriteLine("3. Editar Autor");
        Console.WriteLine("4. Eliminar Autor");
        Console.WriteLine("5. Salir");
        Console.Write("Opción: ");
        opcionAutor = int.Parse(Console.ReadLine());
        Console.WriteLine();
        switch (opcionAutor)
        {
          case 1:
            List<Autor> listaAutores = autoresRepository.ObtenerAutores();
            for (var i = 0; i < listaAutores.Count; i++)
            {
              Console.WriteLine($"Indice: {i + 1}");
              Console.WriteLine($"Nombre: {listaAutores[i].Nombre}");
              Console.WriteLine($"Fecha Nacimiento: {listaAutores[i].FechaNacimiento.Year}");
              Console.WriteLine($"Nacionalidad: {listaAutores[i].Nacionalidad}");
              Console.WriteLine($"Libros:");

              foreach (var l in listaAutores[i].Libros)
              {
                Console.WriteLine($"- {l}");
              }

              Console.WriteLine("--------------------------------------- \n");
            }
            break;

          case 2:
            Console.Write("Nombre: ");
            string agregarNombre = Console.ReadLine();

            Console.Write("Nacionalidad: ");
            string agregarNacionalidad = Console.ReadLine();

            Console.Write("Fecha de nacimiento: ");
            DateTime agregarFechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Libros: ");
            string agregarLibros = Console.ReadLine();
            List<string> agregarLibrosLista = agregarLibros.Split(',').ToList();

            Autor agregarAutor = new(agregarNombre, agregarNacionalidad, agregarFechaNacimiento, agregarLibrosLista);
            autoresRepository.AgregarAutor(agregarAutor);
            Console.WriteLine("Autor Agregado con éxito");
            Console.WriteLine();
            break;

          case 3:
            Console.WriteLine("Escriba el numero del indice del Autor a Editar: ");
            int indiceEditar = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Nombre: ");
            string editarNombre = Console.ReadLine();

            Console.Write("Nacionalidad: ");
            string editarNacionalidad = Console.ReadLine();

            Console.Write("Fecha de nacimiento: ");
            DateTime editarFechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Libros: ");
            string editarLibros = Console.ReadLine();
            List<string> editarLibrosLista = editarLibros.Split(',').ToList();

            Autor editarAutor = new(editarNombre, editarNacionalidad, editarFechaNacimiento, editarLibrosLista);
            autoresRepository.EditarAutor(indiceEditar, editarAutor);
            Console.WriteLine("Autor Editado con éxito");
            Console.WriteLine();
            break;

          case 4:
            Console.WriteLine("Escriba el numero del indice del Autor a Eliminar: ");
            int indiceEliminar = int.Parse(Console.ReadLine()) - 1;
            autoresRepository.EliminarAutor(indiceEliminar);
            Console.WriteLine("Autor Eliminado con éxito");
            Console.WriteLine();
            break;

          case 5:
            Console.WriteLine("Saliendo");
            break;

          default:
            Console.WriteLine("Opción no válida");
            break;
        }
      }
      break;
    case 3:
      int opcionPrestamo = 0;
      while (opcionPrestamo != 4)
      {
        Console.WriteLine("1. Obtener la lista de los Prestamos");
        Console.WriteLine("2. Agregar Prestamo");
        Console.WriteLine("3. Registrar Fecha de devolucion");
        Console.WriteLine("4. Salir");
        Console.Write("Opción: ");
        opcionPrestamo = int.Parse(Console.ReadLine());
        Console.WriteLine();
        switch (opcionPrestamo)
        {
          case 1:
            List<Prestamo> prestamosLibros = prestamosLibrosRepository.ObtenerPrestamos();
            for (var i = 0; i < prestamosLibros.Count; i++)
            {
              Console.WriteLine($"Indice: {i + 1}");
              Console.WriteLine($"Titulo: {prestamosLibros[i].LibroPrestado}");
              Console.WriteLine($"Autor: {prestamosLibros[i].Autor}");
              Console.WriteLine($"Fecha de prestamo: {prestamosLibros[i].FechaPrestamo.ToShortDateString()}");
              Console.WriteLine($"Estado: {prestamosLibros[i].FechaDevolucion?.ToShortDateString() ?? "Sin registro de devolución"}");
              Console.WriteLine("---------------------------------------");
            }
            break;

          case 2:
            Console.Write("Titulo del Libro a Prestar: ");
            string libroPrestado = Console.ReadLine();

            Console.Write("Autor del Libro a Prestar: ");
            string autor = Console.ReadLine();

            Console.Write("Fecha de Prestamo: ");
            DateTime fechaPrestamo = DateTime.Parse(Console.ReadLine());

            Prestamo prestamo = new(libroPrestado, autor, fechaPrestamo);
            prestamosLibrosRepository.AgregarPrestamo(prestamo);
            Console.WriteLine("Prestamo Agregado con éxito");
            Console.WriteLine();
            break;

          case 3:
            Console.Write("Escriba el numero del indice del Prestamo a Devolver: ");
            int indiceDevolver = int.Parse(Console.ReadLine()) - 1;
            prestamosLibrosRepository.DevolverPrestamo(indiceDevolver);
            Console.WriteLine("Libro Devuelto con éxito");
            Console.WriteLine();

            break;

          case 4:
            Console.Write("Saliendo");
            break;

          default:
            Console.WriteLine("Opción no válida");
            break;
        }
      }
      break;

    case 4:
      Console.WriteLine("Adiós");
      break;

    default:
      Console.WriteLine("Opción no válida");
      break;
  }
}

