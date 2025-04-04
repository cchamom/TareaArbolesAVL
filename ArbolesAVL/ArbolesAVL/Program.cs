using System;
using System.Diagnostics;
using ArbolesAVL;

namespace ArbolesAVL
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolAVL arbol = new ArbolAVL();
           
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
                Console.WriteLine("9. Eliminar Nodo");
                Console.WriteLine("10.Medir Tiempo");
                Console.WriteLine("11.Salir");
                Console.WriteLine("");
                Console.WriteLine("-------------------------------");
                Console.Write("Opción: ");
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el valor del nodo: ");
                        string? valor = Console.ReadLine();
                        if (int.TryParse(valor, out int nodoValor))
                        {
                            arbol.Add(nodoValor);
                        }
                        else
                        {
                            Console.WriteLine("Valor no válido. Por favor, ingrese un número entero.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Recorrido PreOrden:");
                        arbol.PreOrden(arbol.obtenerRaiz());
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("Recorrido InOrden:");
                        arbol.InOrden(arbol.obtenerRaiz());
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Recorrido PostOrden:");
                        arbol.PostOrden(arbol.obtenerRaiz());
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine("Altura del árbol: " + arbol.Altura(arbol.obtenerRaiz()));
                        break;
                    case "6":
                        Console.WriteLine("Grado del árbol: " + arbol.ObtenerGrado());
                        break;
                    case "7":
                        Console.WriteLine("Gráfica del árbol:");
                        arbol.ImprimirArbol(arbol.obtenerRaiz());
                        break;
                    case "8":
                        Console.Write("Ingrese el valor a buscar: ");
                        string? buscar = Console.ReadLine();
                        if (int.TryParse(buscar, out int buscarValor))
                        {
                            List<string> camino = new List<string>();
                            if (arbol.Buscar(arbol.obtenerRaiz(), buscarValor.ToString(), camino))
                            {
                                Console.WriteLine($"El valor fue encontrado. Camino: {string.Join(" -> ", camino)}");
                            }
                            else
                            {
                                Console.WriteLine("El valor no fue encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor no válido. Por favor, ingrese un número entero.");
                        }
                        break;
                    case "9":
                        Console.Write("Ingresa el Nodo que quieras eliminar: ");
                        string? eliminar = Console.ReadLine();

                        if (int.TryParse(eliminar, out int valorEliminar))
                        {
                            Console.WriteLine("---- Antes de eliminar el nodo ----");
                            arbol.ImprimirArbol(arbol.obtenerRaiz());

                            arbol.BorrarNodo(arbol.obtenerRaiz(), valorEliminar);
                            Console.WriteLine("Árbol después de la eliminación:");
                            arbol.ImprimirArbol(arbol.obtenerRaiz());

                            // Aplicar balanceo
                            arbol.BorrarConBalanceo(arbol.obtenerRaiz(), valorEliminar);
                            Console.WriteLine("Árbol después del balanceo:");
                            arbol.ImprimirArbol(arbol.obtenerRaiz());
                        }
                        else
                        {
                            Console.WriteLine("Valor no válido");
                        }
                        break;
                   /* case "10":
                        Console.WriteLine("Midiendo tiempos de operaciones...");
                       // arbol.MedirTiempo(arbol);
                        break; */
                    case "11":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
