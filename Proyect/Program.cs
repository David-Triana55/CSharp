AutorRepository autoresRepository = new();
LibroRepository librosRepository = new();
PrestamoRepository prestamosLibrosRepository = new(autoresRepository, librosRepository);

Console.WriteLine("Bienvenido");
int menu = 0;
while (menu != 4)
{
  menu = MenuPrincipal();
  switch (menu)
  {
    case 1:
      int opcionLibro = 0;
      while (opcionLibro != 5)
      {
        opcionLibro = MenuLibros();
        switch (opcionLibro)
        {
          case 1:
            ObtenerListaDeLibros();
            break;

          case 2:
            AgregarNuevoLibro();
            break;

          case 3:
            EditarLibro();
            break;

          case 4:
            EliminarLibro();
            break;

          case 5:
            Saliendo();
            break;

          default:
            OpcionNoValida();
            break;
        }
      }
      break;

    case 2:
      int opcionAutor = 0;
      while (opcionAutor != 5)
      {
        opcionAutor = MenuAutores();
        switch (opcionAutor)
        {
          case 1:
            ObtenerListaDeAutores();
            break;

          case 2:
            AgregarNuevoAutor();
            break;

          case 3:
            EditarAutor();
            break;

          case 4:
            EliminarAutor();
            break;

          case 5:
            Saliendo();
            break;

          default:
            OpcionNoValida();
            break;
        }
      }
      break;

    case 3:
      int opcionPrestamo = 0;
      while (opcionPrestamo != 4)
      {
        opcionPrestamo = MenuPrestamos();
        switch (opcionPrestamo)
        {
          case 1:
            ObtenerListaDePrestamos();
            break;

          case 2:
            AgregarPrestamo();
            break;

          case 3:
            RegistrarDevolucion();
            break;

          case 4:
            Saliendo();
            break;

          default:
            OpcionNoValida();
            break;
        }
      }
      break;

    case 4:
      Console.WriteLine("Adiós");
      break;

    default:
      OpcionNoValida();
      break;
  }
}

int MenuPrincipal()
{
  try
  {
    Console.WriteLine("1. Gestrionar Libros");
    Console.WriteLine("2. Gestionar Autores");
    Console.WriteLine("3. Gestionar Prestamos");
    Console.WriteLine("4. Salir\n");
    Console.Write("Opción: ");
    int opcionSeleccionada = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcionSeleccionada;
  }
  catch (FormatException)
  {
    Console.WriteLine("Opción no válida");
    return 0;
  }
}

// Libros

int MenuLibros()
{
  try
  {
    Console.WriteLine("1. Obtener la lista de los libros");
    Console.WriteLine("2. Agregar Libro");
    Console.WriteLine("3. Editar Libro");
    Console.WriteLine("4. Eliminar Libro");
    Console.WriteLine("5. Salir");
    Console.Write("Opción: ");

    int opcionSeleccionada = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcionSeleccionada;
  }
  catch (FormatException)
  {
    Console.WriteLine("Opción no válida");
    return 0;
  }
}

void ObtenerListaDeLibros()
{
  List<Libro> listaLibros = librosRepository.ObtenerLibros(); // 
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
}

void AgregarNuevoLibro()
{
  try
  {
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
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

void EditarLibro()
{
  try
  {
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
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

void EliminarLibro()
{
  try
  {
    Console.Write("Escriba el numero del indice del libro a Eliminar: ");
    int indiceEliminar = int.Parse(Console.ReadLine()) - 1;
    librosRepository.EliminarLibro(indiceEliminar);
    Console.WriteLine("Libro Eliminado con éxito");
    Console.WriteLine();
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

// Autores

int MenuAutores()
{
  try
  {
    Console.WriteLine("1. Obtener la lista de los Autores");
    Console.WriteLine("2. Agregar Autor");
    Console.WriteLine("3. Editar Autor");
    Console.WriteLine("4. Eliminar Autor");
    Console.WriteLine("5. Salir");
    Console.Write("Opción: ");
    int opcionSeleccionada = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcionSeleccionada;
  }
  catch (FormatException)
  {
    Console.WriteLine("Opción no válida");
    return 0;
  }
}

void ObtenerListaDeAutores()
{
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
}

void AgregarNuevoAutor()
{
  try
  {
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
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

void EditarAutor()
{
  try
  {
    Console.WriteLine("Escriba el numero del indice del Autor a Editar: "); // EditarAutor();
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
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

void EliminarAutor()
{
  try
  {
    Console.WriteLine("Escriba el numero del indice del Autor a Eliminar: ");
    int indiceEliminar = int.Parse(Console.ReadLine()) - 1;
    autoresRepository.EliminarAutor(indiceEliminar);
    Console.WriteLine("Autor Eliminado con éxito");
    Console.WriteLine();
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

// prestamos

int MenuPrestamos()
{
  try
  {
    Console.WriteLine("1. Obtener la lista de los Prestamos");
    Console.WriteLine("2. Agregar Prestamo");
    Console.WriteLine("3. Registrar Fecha de devolucion");
    Console.WriteLine("4. Salir");
    Console.Write("Opción: ");
    int numeroSeleccionado = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return numeroSeleccionado;
  }
  catch (FormatException)
  {
    Console.WriteLine("Opción no válida");
    return 0;
  }
}

void ObtenerListaDePrestamos()
{
  List<Prestamo> prestamosLibros = prestamosLibrosRepository.ObtenerPrestamos(); // 
  if (prestamosLibros.Count == 0)
  {
    Console.WriteLine("No hay prestamos registrados");
    return;
  }
  for (var i = 0; i < prestamosLibros.Count; i++)
  {
    Console.WriteLine($"Indice: {i + 1}");
    Console.WriteLine($"Titulo: {prestamosLibros[i].LibroPrestado}");
    Console.WriteLine($"Autor: {prestamosLibros[i].Autor}");
    Console.WriteLine($"Fecha de prestamo: {prestamosLibros[i].FechaPrestamo.ToShortDateString()}");
    Console.WriteLine($"Estado: {prestamosLibros[i].FechaDevolucion?.ToShortDateString() ?? "Sin registro de devolución"}");
    Console.WriteLine("---------------------------------------");
  }
}

void AgregarPrestamo()
{
  try
  {
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
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

void RegistrarDevolucion()
{
  try
  {
    Console.Write("Escriba el numero del indice del Prestamo a Devolver: ");
    int indiceDevolver = int.Parse(Console.ReadLine()) - 1;
    prestamosLibrosRepository.DevolverPrestamo(indiceDevolver);
    Console.WriteLine("Libro Devuelto con éxito");
    Console.WriteLine();
  }
  catch (FormatException)
  {
    Console.WriteLine("Formato inválido");
  }
}

void Saliendo()
{
  Console.WriteLine("Saliendo");
}

void OpcionNoValida()
{
  Console.WriteLine("Opción no válida");
}