using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public class Vector3<T> where T : struct, IComparable
    {
        public T X { get; private set; }
        public T Y { get; private set; }
        public T Z { get; private set; }
        public Vector3(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3<T> vector3))
                return false;
            return vector3.X.Equals(X) && vector3.Y.Equals(Y) && vector3.Z.Equals(Z);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Z.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"<{X},{Y},{Z}>";
        }
    }
}
