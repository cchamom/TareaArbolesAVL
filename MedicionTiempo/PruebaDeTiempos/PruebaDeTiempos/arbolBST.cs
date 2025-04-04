using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDeTiempos
{
    //Creamos una clase donde este el algoritmo de arboles por BST

    public class arbolBST
    {
        private NodoBST root;

        public void Insert(int value)
        {
            root = Insert(root, value);
        }

        private NodoBST Insert(NodoBST node, int value)
        {
            if (node == null)
                return new NodoBST(value);

            if (value < node.Value)
                node.Left = Insert(node.Left, value);
            else if (value > node.Value)
                node.Right = Insert(node.Right, value);

            return node;
        }

        public bool Search(int value)
        {
            return Search(root, value);
        }

        private bool Search(NodoBST node, int value)
        {
            if (node == null) return false;
            if (node.Value == value) return true;
            if (value < node.Value)
                return Search(node.Left, value);
            else
                return Search(node.Right, value);
        }

        public void Delete(int value)
        {
            root = Delete(root, value);
        }

        private NodoBST Delete(NodoBST node, int value)
        {
            if (node == null) return null;

            if (value < node.Value)
                node.Left = Delete(node.Left, value);
            else if (value > node.Value)
                node.Right = Delete(node.Right, value);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                NodoBST minLargerNode = FindMin(node.Right);
                node.Value = minLargerNode.Value;
                node.Right = Delete(node.Right, minLargerNode.Value);
            }

            return node;
        }

        private NodoBST FindMin(NodoBST node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }
    }

}
