int ladoA; // declarar la varibale
int ladoB;
int resultado;

Console.WriteLine("Programa para calcular el area de un rectangulo");
Console.WriteLine("Ingrese el valor del ladoA");
ladoA = Convert.ToInt32(Console.ReadLine()); // leer un valor de la consola y asignarlo

Console.WriteLine("Ingrese el valor del ladoB");
ladoB = Convert.ToInt32(Console.ReadLine()); // convertir cadena de texto a entero

resultado = ladoA * ladoB;
Console.WriteLine("El resultado de la area del rectangulo es: " + resultado);

// var se usa para declarar de forma implicita variables sin embargo se tiene que inicializar

// var ladoC = 0;

// en las constantes por convencion siempre deben empezar en mayusculas => const double Pi = 3.14

/*
== igual a
!= diferente a
>  mayor a 
<  menor a
*/

// if

int numero1 = 1;
int numero2 = 3;

if (numero1 > numero2)
{
  Console.WriteLine("numero 1 es mayor");
}
else if (numero2 > numero1)
{
  Console.WriteLine("El numero 2 es mayor");
}

// Switch

string number;
int opt = 2;

switch (opt)
{
  case 1:
    number = "One";
    break;
  case 2:
    number = "Two";
    break;
  default:
    number = "Error";
    break;
}
Console.WriteLine("El número es: " + number);