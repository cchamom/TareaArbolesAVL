using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDeTiempos
{ 
    //Creamos una clase donde este el algoritmo de arboles por AVL
    public class arbolAVL
    {
        private Nodo root;

        public void Insertar(int value)
        {
            root = Insertar(root, value);
        }

        private Nodo Insertar(Nodo node, int value)
        {
            if (node == null) return new Nodo(value);

            if (value < node.Value)
                node.Left = Insertar(node.Left, value);
            else if (value > node.Value)
                node.Right = Insertar(node.Right, value);
            else
                return node;

            UpdateHeight(node);
            return Balance(node);
        }

        public bool Buscar(int value)
        {
            return Buscar(root, value);
        }

        private bool Buscar(Nodo node, int value)
        {
            if (node == null) return false;
            if (value == node.Value) return true;
            if (value < node.Value)
                return Buscar(node.Left, value);
            return Buscar(node.Right, value);
        }

        public void Borrar(int value)
        {
            root = Borrar(root, value);
        }

        private Nodo Borrar(Nodo node, int value)
        {
            if (node == null) return node;

            if (value < node.Value)
                node.Left = Borrar(node.Left, value);
            else if (value > node.Value)
                node.Right = Borrar(node.Right, value);
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    node = node.Left ?? node.Right;
                }
                else
                {
                    Nodo temp = GetMinValueNode(node.Right);
                    node.Value = temp.Value;
                    node.Right = Borrar(node.Right, temp.Value);
                }
            }

            if (node == null) return node;

            UpdateHeight(node);
            return Balance(node);
        }

        private void UpdateHeight(Nodo node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        private int GetHeight(Nodo node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(Nodo node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private Nodo Balance(Nodo node)
        {
            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (GetBalance(node.Left) < 0)
                    node.Left = RotacionIzquierda(node.Left);
                return RotacuionDerecha(node);
            }
            if (balance < -1)
            {
                if (GetBalance(node.Right) > 0)
                    node.Right = RotacuionDerecha(node.Right);
                return RotacionIzquierda(node);
            }

            return node;
        }

        private Nodo RotacuionDerecha(Nodo y)
        {
            Nodo x = y.Left;
            Nodo T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private Nodo RotacionIzquierda(Nodo x)
        {
            Nodo y = x.Right;
            Nodo T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        private Nodo GetMinValueNode(Nodo node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }
    }

}
