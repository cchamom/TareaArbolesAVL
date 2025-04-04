using System;
using System.Collections.Generic;

class Nodo
{
    public string valor;
    public Nodo izquierdo;
    public Nodo derecho;

    public Nodo(string valor)
    {
        this.valor = valor;
        this.izquierdo = null;
        this.derecho = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    public void Agregar(string valor)
    {
        raiz = AgregarRecursivo(raiz, valor);
    }

    private Nodo AgregarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        Console.Write($"¿El nodo {valor} va a la izquierda o derecha de {nodo.valor}? (I/D): ");
        string direccion = Console.ReadLine().ToUpper();

        if (direccion == "I")
            nodo.izquierdo = AgregarRecursivo(nodo.izquierdo, valor);
        else
            nodo.derecho = AgregarRecursivo(nodo.derecho, valor);

        return nodo;
    }

    public void PreOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.valor + " ");
            PreOrden(nodo.izquierdo);
            PreOrden(nodo.derecho);
        }
    }

    public void InOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.izquierdo);
            Console.Write(nodo.valor + " ");
            InOrden(nodo.derecho);
        }
    }

    public void PostOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.izquierdo);
            PostOrden(nodo.derecho);
            Console.Write(nodo.valor + " ");
        }
    }

    public int Altura(Nodo nodo)
    {
        if (nodo == null)
            return 0;
        return 1 + Math.Max(Altura(nodo.izquierdo), Altura(nodo.derecho));
    }

    public int Grado(Nodo nodo)
    {
        if (nodo == null)
            return 0;
        int gradoActual = (nodo.izquierdo != null ? 1 : 0) + (nodo.derecho != null ? 1 : 0);
        return Math.Max(gradoActual, Math.Max(Grado(nodo.izquierdo), Grado(nodo.derecho)));
    }

    public void ImprimirArbol(Nodo nodo, int nivel = 0)
    {
        if (nodo == null)
            return;

        ImprimirArbol(nodo.derecho, nivel + 1);
        Console.WriteLine(new string(' ', nivel * 4) + nodo.valor);
        ImprimirArbol(nodo.izquierdo, nivel + 1);
    }

    public bool Buscar(Nodo nodo, string valor, List<string> camino)
    {
        if (nodo == null)
            return false;

        camino.Add(nodo.valor);

        if (nodo.valor == valor)
            return true;

        if (Buscar(nodo.izquierdo, valor, camino) || Buscar(nodo.derecho, valor, camino))
            return true;

        camino.RemoveAt(camino.Count - 1);
        return false;
    }
}
