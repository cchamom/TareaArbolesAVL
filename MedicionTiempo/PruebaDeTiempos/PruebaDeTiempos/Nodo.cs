using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PruebaDeTiempos
{
    public class Nodo
    {

        public int Value;
        public Nodo Left, Right;
        public int Height;

        public Nodo(int value)
        {
            Value = value;
            Height = 1;
        }
    }
    public class NodoBST
    {
        public int Value;
        public NodoBST Left, Right;

        public NodoBST(int value)
        {
            Value = value;
        }
    }
}
