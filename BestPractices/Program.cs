List<string> TaskList = new List<string>();

int menuSelected;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add) // se convierte el tipo de dato de la variable menuSelected a Menu
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove) //2
    {
        ShowMenuRemove();
    }

    else if ((Menu)menuSelected == Menu.List) //3
    {
        ShowMenuList();
    }
} while ((Menu)menuSelected != Menu.Exit); //4

/// <summary>
/// Muestra el menú principal del programa
/// </summary>
/// <returns>El número de la opción seleccionada</returns>

int ShowMainMenu()
{
    try
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        string input = Console.ReadLine(); 

        // Intenta convertir la entrada al tipo int y almacenarla en optionSelected
        if (!int.TryParse(input, out int optionSelected)) 
        {
            Console.WriteLine("Opción no válida, ingrese un número");
            return ShowMainMenu();
        }

        if (optionSelected < 1 || optionSelected > 4) 
        {
            Console.WriteLine("El número de opción no es válido");
            return ShowMainMenu();
        }

        return optionSelected;
    }
    catch (Exception)
    {
        Console.WriteLine("Opción no válida");
        return ShowMainMenu(); 
    }
}
void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        
        ShowMenuList();

        // usamos el -1 ya que el primer elemento de la lista es el indice 0
        int indexToRemove = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indexToRemove > TaskList.Count - 1 || indexToRemove < 0)
        {
            Console.WriteLine("El número de tarea no es válido");
        }
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Número de tarea no válido");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskToAdd = Console.ReadLine();
        TaskList.Add(taskToAdd);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
        Console.WriteLine("Error al ingresar tarea");
    }
}

void ShowMenuList()
{
    if (TaskList == null || TaskList.Count == 0)
    {
        Console.WriteLine("No hay tareas por realizar");
    }
    else
    {
        Console.WriteLine("----------------------------------------");
        for (int i = 0; i < TaskList.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{TaskList[i]}");
        }
        Console.WriteLine("----------------------------------------");
    }
}
public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
