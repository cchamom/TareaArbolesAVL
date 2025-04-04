using System;

namespace ArbolesAVL
{
    //Clase que representa un nodo en el árbol AVL
    public class NodoAVL
    {
        public int data;
        public NodoAVL left;
        public NodoAVL right;
        public int height;

        public NodoAVL(int data)
        {
            this.data = data;
            this.height = 1;
        }
    }
}
