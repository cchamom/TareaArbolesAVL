using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        while (true)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("\nSeleccione una operación:");
            Console.WriteLine("1. Agregar nodo");
            Console.WriteLine("2. PreOrden");
            Console.WriteLine("3. InOrden");
            Console.WriteLine("4. PostOrden");
            Console.WriteLine("5. Calcular altura del árbol");
            Console.WriteLine("6. Calcular grado del árbol");
            Console.WriteLine("7. Imprimir árbol");
            Console.WriteLine("8. Buscar un valor");
            Console.WriteLine("9. Salir");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el valor del nodo(Debe de seleccionar la opcion 1 para ingresar otro nodo): ");
                    string valor = Console.ReadLine();
                    arbol.Agregar(valor);
                    break;
                case "2":
                    Console.WriteLine("Recorrido PreOrden:");
                    arbol.PreOrden(arbol.raiz);
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.InOrden(arbol.raiz);
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine("Recorrido PostOrden:");
                    arbol.PostOrden(arbol.raiz);
                    Console.WriteLine();
                    break;
                case "5":
                    Console.WriteLine("Altura del árbol: " + arbol.Altura(arbol.raiz));
                    break;
                case "6":
                    Console.WriteLine("Grado del árbol: " + arbol.Grado(arbol.raiz));
                    break;
                case "7":
                    Console.WriteLine("Grafuca del arbol:");
                    arbol.ImprimirArbol(arbol.raiz);
                    break;
                case "8":
                    Console.Write("Ingrese el valor a buscar: ");
                    string buscar = Console.ReadLine();
                    List<string> camino = new List<string>();
                    if (arbol.Buscar(arbol.raiz, buscar, camino))
                    {
                        Console.WriteLine($"El valor fue encontrado. Camino: {string.Join(" -> ", camino)}");
                    }
                    else
                    {
                        Console.WriteLine("El valor no fue encontrado.");
                    }
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
}