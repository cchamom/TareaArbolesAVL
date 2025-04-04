using PruebaDeTiempos;
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        //creamos un objeto de la clase Random para generar números aleatorios y tamabin un objeto de la clase Stopwatch para medir el tiempo
        Random random = new Random();
        Stopwatch stopwatch = Stopwatch.StartNew();

        //Array para almacenar los datos
        int[] array = new int[10000];

        // hacer un ciclo for para generar los datos 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 10000);
        }

        //Medimos el tiempo
        //Luego insertamos los datos en AVL
        arbolAVL AVL = new arbolAVL();
        foreach (int item in array)
        {
            AVL.Insertar(item);
        }
        stopwatch.Stop();
        Console.WriteLine("Tiempo de inserción en AVL: " + stopwatch.ElapsedTicks + " ticks");

        // Ahora insertamos los datos en un árbol binario
        arbolBST BST = new arbolBST();
        foreach (int item in array)
        {
            BST.Insert(item);
        }
        stopwatch.Restart();
        Console.WriteLine("Tiempo de inserción en BST: " + stopwatch.ElapsedTicks + " ticks");

        //Tdnmos que buscar el primer elemento, el elemento medio y el último elemento
        int primerElemento = array[0];
        int elementoMedio = array[array.Length / 2];
        int ultimoElemento = array[array.Length - 1];
        stopwatch.Restart();

        //Busqueda en AVl
        Console.WriteLine("Primer elemento: " + primerElemento);
        Console.WriteLine("Elemento medio: " + elementoMedio);
        Console.WriteLine("Último elemento: " + ultimoElemento);

        AVL.Buscar(primerElemento);
        AVL.Buscar(elementoMedio);
        AVL.Buscar(ultimoElemento);
        stopwatch.Stop();
        Console.WriteLine("-----BUSQUEDA------");
        Console.WriteLine("Tiempo de búsqueda en AVL: " + stopwatch.ElapsedTicks + " ticks");
        stopwatch.Restart();

        //Buscamos en BST
        BST.Search(primerElemento);
        BST.Search(elementoMedio);
        BST.Search(ultimoElemento); 
        Console.WriteLine("Tiempo de búsqueda en BST: " + stopwatch.ElapsedTicks + " ticks");
        stopwatch.Stop();

        //Medimos el tiempo de eliminación en AVL
        int eliminar = array[0];
        stopwatch.Restart();
        Console.WriteLine("----Eliminar------");
        Console.WriteLine($"Eliminando en BST: " + eliminar);
        Console.WriteLine($"Eliminando en AVL: " + eliminar);
        AVL.Borrar(eliminar);
        stopwatch.Stop();
        Console.WriteLine("Tiempo de eliminación en AVL: " + stopwatch.ElapsedTicks + " ticks");
        BST.Delete(eliminar);
        stopwatch.Stop();
        Console.WriteLine("Tiempo de eliminación en BST: " + stopwatch.ElapsedTicks + " ticks");
    }
}

