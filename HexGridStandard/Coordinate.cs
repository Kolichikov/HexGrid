using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public abstract class Coordinate
    {
        protected float Size { get; set; } = 1f;

        public Vector3<int> Position { get; set; }

        public abstract bool IsCube();
        protected Coordinate(){}

        protected Coordinate(int x, int y, int z)
        {
            Position = new Vector3<int>(x, y, z);
        }

        public float Distance(Coordinate c)
        {
            var position1 = ConvertToCube().Position;
            var position2 = c.ConvertToCube().Position;
            return (float)((Math.Abs(position1.X - position2.X) + (double)Math.Abs(position1.Y - position2.Y) + Math.Abs(position1.Z - position2.Z)) / 2.0);
        }

        public CubeCoordinate NearestHex()
        {
            var cube = ConvertToCube();
            var num1 = cube.Position.X;
            var num2 = cube.Position.Y;
            var num3 = cube.Position.Z;
            var num4 = Math.Abs(num1 - cube.Position.X);
            var num5 = Math.Abs(num2 - cube.Position.Y);
            var num6 = Math.Abs(num3 - cube.Position.Z);
            if (num4 > num5 && num4 > num6)
                num1 = -num2 - num3;
            else if (num5 > num6)
                num2 = -num1 - num3;
            else
                num3 = -num1 - num2;
            return new CubeCoordinate(num1, num2, num3);
        }

        public abstract CubeCoordinate ConvertToCube();

        public T Add<T>(T c1) where T : Coordinate, new()
        {
            var obj = new T();
            obj.Position = new Vector3<int>(c1.Position.X + Position.X, c1.Position.Y + Position.Y, c1.Position.Z + Position.Z);
            return obj;
        }

        public T Subtract<T>(T c1) where T : Coordinate, new()
        {
            var obj = new T();
            obj.Position = new Vector3<int>(Position.X - c1.Position.X, Position.Y - c1.Position.Y, Position.Z - c1.Position.Z);
            return obj;
        }
    }
}
