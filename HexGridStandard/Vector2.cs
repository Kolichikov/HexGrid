using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public class Vector2<T> where T : struct, IComparable
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Vector2(){ }

        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }
    }
}
