using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ArbolesAVL
{
    internal class ArbolAVL
    {
        public NodoAVL raiz;

        public ArbolAVL()
        {
            raiz = null;
        }


        //Obtenemos la riz del nodo
        public NodoAVL obtenerRaiz() => raiz;

        public void Add(int data)
        {
            NodoAVL newItem = new NodoAVL(data);
            if (raiz == null)
            {
                raiz = newItem;
            }
            else
            {
                raiz = InsertarRecursividad(raiz, newItem);
            }
        }

        //Este método se llama recursivamente para encontrar la posición correcta del nuevo nodo en el árbol.
        private NodoAVL InsertarRecursividad(NodoAVL current, NodoAVL n)
        {
            if (current == null)
            {
                return n;
            }

            //comparamos el valor del nuevo nodo con el nodo actual
            if (n.data < current.data)
            {
                current.left = InsertarRecursividad(current.left, n);
            }
            //si el valor es mayor, lo insertamos en el subárbol derecho
            else if (n.data > current.data)
            {
                current.right = InsertarRecursividad(current.right, n);
            }
            //si el valor ya existe, no hacemos nada
            else
            {
                return current;
            }
            //se actualiza la altura del nodo actual
            current.height = 1 + Math.Max(GetHeight(current.left), GetHeight(current.right));
            return Balancear(current);
        }

        //Este método se encarga de balancear el árbol AVL después de cada inserción o eliminación.
        private NodoAVL Balancear(NodoAVL current)
        {
            int balance = balance_factor(current);

            if (balance > 1 && balance_factor(current.left) >= 0)
            {
                return RotacionLL(current);
            }
            if (balance > 1 && balance_factor(current.left) < 0)
            {
                return RotacionLR(current);
            }
            if (balance < -1 && balance_factor(current.right) <= 0)
            {
                return RotacionRR(current);
            }
            if (balance < -1 && balance_factor(current.right) > 0)
            {
                return RotacionRL(current);
            }

            return current;
        }
        //Metodos con las rotaciones requeridas por AVL
        private NodoAVL RotacionRR(NodoAVL parent)
        {
            NodoAVL pivote = parent.right;
            parent.right = pivote.left;
            pivote.left = parent;
            //para actualizar los nodos después de la rotación
            parent.height = 1 + Math.Max(GetHeight(parent.left), GetHeight(parent.right));
            pivote.height = 1 + Math.Max(GetHeight(pivote.left), GetHeight(pivote.right));
            return pivote;
        }

        private NodoAVL RotacionLL(NodoAVL parent)
        {
            NodoAVL pivote = parent.left;
            parent.left = pivote.right;
            pivote.right = parent;
            //para actualizar los nodos después de la rotación
            parent.height = 1 + Math.Max(GetHeight(parent.left), GetHeight(parent.right));
            pivote.height = 1 + Math.Max(GetHeight(pivote.left), GetHeight(pivote.right));
            return pivote;
        }

        private NodoAVL RotacionLR(NodoAVL parent)
        {
            parent.left = RotacionRR(parent.left);
            return RotacionLL(parent);
        }

        private NodoAVL RotacionRL(NodoAVL parent)
        {
            parent.right = RotacionLL(parent.right);
            return RotacionRR(parent);
        }

        private int balance_factor(NodoAVL current)
        {
            return GetHeight(current.left) - GetHeight(current.right);
        }

        private int GetHeight(NodoAVL current)
        {
            return current == null ? 0 : current.height;
        }

        public void PreOrden(NodoAVL nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.data + " ");
                PreOrden(nodo.left);
                PreOrden(nodo.right);
            }
        }

        //Estos metodo se utilizaron en la tarea anterio en los arbols de BST(busqueda binaria). Se implemtan en el arbol AVL
        public void InOrden(NodoAVL nodo)
        {
            if (nodo != null)
            {
                InOrden(nodo.left);
                Console.Write(nodo.data + " ");
                InOrden(nodo.right);
            }
        }

        public void PostOrden(NodoAVL nodo)
        {
            if (nodo != null)
            {
                PostOrden(nodo.left);
                PostOrden(nodo.right);
                Console.Write(nodo.data + " ");
            }
        }

        public int Altura(NodoAVL nodo)
        {
            return nodo == null ? 0 : nodo.height;
        }
        //Metodo para imprimir el arbol
        public void ImprimirArbol(NodoAVL nodo, int nivel = 0)
        {
            if (nodo == null)
                return;

            ImprimirArbol(nodo.right, nivel + 1);
            Console.WriteLine(new string(' ', nivel * 4) + nodo.data);
            ImprimirArbol(nodo.left, nivel + 1);
        }
        //Usamos este metodo para buscar un nodo en el arbol
        public bool Buscar(NodoAVL nodo, string valor, List<string> camino)
        {
            if (nodo == null)
                return false;

            camino.Add(nodo.data.ToString());
            //Comparamos el valor del nodo actual con el valor buscado
            if (nodo.data.ToString() == valor)
                return true;
            //Si el valor no es igual al nodo actual, se busca en los hijos izquierdo y derecho
            //Aquí se hacen llamadas recursivas a la función Buscar
            if (Buscar(nodo.left, valor, camino) || Buscar(nodo.right, valor, camino))
                return true;

            camino.RemoveAt(camino.Count - 1);
            return false;
        }

        //Metodo para obtener el grado del arbol
        public int ObtenerGrado()
        {
            return ObtenerGradoRecursivo(raiz);
        }

        public int ObtenerGradoRecursivo(NodoAVL nodo)
        {
            if (nodo == null)
                return 0;

            int gradoIzquierda = ObtenerGradoRecursivo(nodo.left);
            int gradoDerecha = ObtenerGradoRecursivo(nodo.right);
            return Math.Max(gradoIzquierda, gradoDerecha) + 1;
        }

        //Metodo para poder eliminar un nodo    
        public NodoAVL BorrarNodo(NodoAVL current, int target)
        {
            if (current == null)
                return null;

            if (target < current.data)
            {
                current.left = BorrarNodo(current.left, target);
            }
            else if (target > current.data)
            {
                current.right = BorrarNodo(current.right, target);
            }
            else
            {
                //Nodo con un solo hijo o sin hijos
                if (current.left == null) return current.right;
                if (current.right == null) return current.left;

                //Nodo con dos hijos: obtener el sucesor en inorden (menor en el subárbol derecho)
                NodoAVL sucesor = MinimoValorNodo(current.right);
                current.data = sucesor.data;
                current.right = BorrarNodo(current.right, sucesor.data);
            }
            current.height = 1 + Math.Max(GetHeight(current.left), GetHeight(current.right));
            //luego de obtener la altura hay que balancear el árbol
            return Balancear(current);
        }

        //para obtener el nodo con el valor mínimo
        private NodoAVL MinimoValorNodo(NodoAVL nodo)
        {
            NodoAVL actual = nodo;
            while (actual.left != null)
            {
                actual = actual.left;
            }
            return actual;
        }

        //metodo para borrar y balancear
        public NodoAVL BorrarConBalanceo(NodoAVL current, int target)
        {
            current = BorrarNodo(current, target);
            if (current == null)
                return null;
            //se acctualizar la altura
            current.height = 1 + Math.Max(GetHeight(current.left), GetHeight(current.right));
            return Balancear(current);
        }

        /*
        public void MedirTiempo(ArbolAVL arbol)
        {
            List<int> valores = new List<int>();
            Random random = new Random();
            int cantidadElementos = 10000;

            // Generar valores aleatorios únicos
            HashSet<int> numUnico = new HashSet<int>();
            while (numUnico.Count < cantidadElementos)
            {
                numUnico.Add(random.Next(1, 10000));
            }
            valores.AddRange(numUnico);

            // Medir el tiempo de inserción
            Stopwatch sw = Stopwatch.StartNew();
            foreach (int i in valores)
            {
                arbol.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"El tiempo de inserción de {cantidadElementos} elementos: {sw.ElapsedMilliseconds} ms");

            int primero = valores[0];
            int medio = valores[valores.Count / 2];
            int ultimo = valores[valores.Count - 1];

            // Medir tiempos de búsqueda
            List<string> caminoBusqueda = new List<string>();

            sw.Restart();
            arbol.Buscar(arbol.obtenerRaiz(), primero.ToString(), caminoBusqueda);
            sw.Stop();
            Console.WriteLine($"Tiempo de búsqueda (inicio - {primero}): {sw.ElapsedTicks} ticks");

            sw.Restart();
            arbol.Buscar(arbol.obtenerRaiz(), medio.ToString(), caminoBusqueda);
            sw.Stop();
            Console.WriteLine($"Tiempo de búsqueda (medio - {medio}): {sw.ElapsedTicks} ticks");

            sw.Restart();
            arbol.Buscar(arbol.obtenerRaiz(), ultimo.ToString(), caminoBusqueda);
            sw.Stop();
            Console.WriteLine($"Tiempo de búsqueda (final - {ultimo}): {sw.ElapsedTicks} ticks");

            // Medir tiempo de eliminación
            sw.Restart();
            arbol.BorrarNodo(arbol.obtenerRaiz(), medio);
            sw.Stop();
            Console.WriteLine($"Tiempo de eliminación del elemento {medio}: {sw.ElapsedMilliseconds} ms");
        } */
    }

}

