using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public class CubeCoordinate : Coordinate
    {
        public static CubeCoordinate Zero = new CubeCoordinate(0, 0, 0);
        public static Dictionary<HexDirections, CubeCoordinate> Directions = new Dictionary<HexDirections, CubeCoordinate>
        {
          {
            HexDirections.TopLeft,
            new CubeCoordinate(0, 1, -1)
          },
          {
            HexDirections.TopRight,
            new CubeCoordinate(1, 0, -1)
          },
          {
            HexDirections.Left,
            new CubeCoordinate(-1, 1, 0)
          },
          {
            HexDirections.Right,
            new CubeCoordinate(1, -1, 0)
          },
          {
            HexDirections.BottomLeft,
            new CubeCoordinate(-1, 0, 1)
          },
          {
            HexDirections.BottomRight,
            new CubeCoordinate(0, -1, 1)
          }
        };

        public CubeCoordinate()
        {
        }

        public CubeCoordinate(int x, int y, int z)
          : base(x, y, z)
        {
        }

        public override bool IsCube()
        {
            return true;
        }

        public CubeCoordinate(Vector3 position)
          : base(position.X, position.Y, position.Z)
        {
        }

        public override CubeCoordinate ConvertToCube()
        {
            return this;
        }

        public CubeCoordinate Neighbour(int direction)
        {
            switch (direction)
            {
                case 0:  
                    return Neighbour(HexDirections.Right);
                case 1:
                    return Neighbour(HexDirections.TopRight);
                case 2:
                    return Neighbour(HexDirections.TopLeft);
                case 3:
                    return Neighbour(HexDirections.Left);
                case 4:
                    return Neighbour(HexDirections.BottomLeft);
                case 5:
                    return Neighbour(HexDirections.BottomRight);
                default:
                    return Neighbour(HexDirections.Right);
            };
        }

        public CubeCoordinate Neighbour(HexDirections direction)
        {
            return Add(Directions[direction]);
        }

        public static CubeCoordinate Neighbour(Vector3 centre, HexDirections direction)
        {
            var d = Directions[direction];
            var obj = new CubeCoordinate(centre.X + d.Position.X, centre.Y + d.Position.Y, centre.Z + d.Position.Z);
            return obj;
        }

        public (float x,float y,float z) ConvertToWorld(float unitZ = float.NaN, Orientation orientation = Orientation.FlatTop)
        {
            if (orientation == Orientation.PointyTop)
                return
                (
                    x: (float)(Size * Math.Sqrt(3.0) * (Position.X + Position.Z / 2.0)),
                    y: -1.5f * Size * Position.Z,
                    z: float.IsNaN(unitZ) ? 0.0f : unitZ
                );
            return
            (
                x: -1.5f * Size * Position.X,
                y: (float)(Size * Math.Sqrt(3.0) * (Position.Z + Position.X / 2.0)),
                z: float.IsNaN(unitZ) ? 0.0f : unitZ
            );
        }

        public AxialCoordinate ConvertToAxial()
        {
            return new AxialCoordinate(Position.X, Position.Z);
        }

        public OffsetCoordinate ConvertToOffset(OffsetType type)
        {
            int column;
            int row;
            switch (type)
            {
                case OffsetType.OddRow:
                column = Position.X + (int)((Position.Z - (double)(Position.Z & 1)) / 2.0);
                row = Position.Z;
                break;
                case OffsetType.EvenRow:
                column = Position.X + (int)((Position.Z + (double)(Position.Z & 1)) / 2.0);
                row = Position.Z;
                break;
                case OffsetType.OddColumn:
                column = Position.X;
                row = Position.Z + (int)((Position.X - (double)(Position.X & 1)) / 2.0);
                break;
                case OffsetType.EvenColumn:
                column = Position.X;
                row = Position.Z + (int)((Position.X + (double)(Position.X & 1)) / 2.0);
                break;
                default:
                throw new ArgumentOutOfRangeException(nameof(type), "Wrong offset type format encountered");
            }
            return new OffsetCoordinate(type, column, row);
        }
    }
}
