using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public struct Vector4 : IEquatable<Vector4>//<T> where T : struct, IComparable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int H { get; private set; }
        public Vector4(int x, int y, int z, int h)
        {
            X = x;
            Y = y;
            Z = z;
            H = h;
        }
        public Vector4(Vector3 position, int height)
        {
            X = position.X;
            Y = position.Y;
            Z = position.Z;
            H = height;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector4 vector4))
                return false;
            return Equals(vector4);
        }

        public bool Equals(Vector4 obj)
        {
            return obj.X ==X && obj.Y == Y && obj.Z ==Z && obj.H == H;
        }

        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector4 left, Vector4 right)
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
                hash = hash * 23 + H.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"<{X},{Y},{Z},{H}>";
        }
    }
}
