using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public struct Vector3 : IEquatable<Vector3>//<T> where T : struct, IComparable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public Vector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3 vector3))
                return false;
            return Equals(vector3);
        }

        public bool Equals(Vector3 obj)
        {
            return obj.X ==X && obj.Y == Y && obj.Z ==Z;
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(right);
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
