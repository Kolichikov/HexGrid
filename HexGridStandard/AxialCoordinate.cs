using System;
using System.Collections.Generic;

namespace HexGridStandard
{
     public class AxialCoordinate : Coordinate
    {
        public static Dictionary<HexDirections, AxialCoordinate> Directions = new Dictionary<HexDirections, AxialCoordinate>
        {
          {
            HexDirections.TopLeft,
            new AxialCoordinate(0, -1)
          },
          {
            HexDirections.TopRight,
            new AxialCoordinate(1, -1)
          },
          {
            HexDirections.Left,
            new AxialCoordinate(-1, 0)
          },
          {
            HexDirections.Right,
            new AxialCoordinate(1, 0)
          },
          {
            HexDirections.BottomLeft,
            new AxialCoordinate(-1, 1)
          },
          {
            HexDirections.BottomRight,
            new AxialCoordinate(0, 1)
          }
        };

        public int Column => Position.X;

        public int Row => Position.Z;

        public AxialCoordinate()
        {
        }

        public AxialCoordinate(int col, int row)
          : base(col, 0, row) { }

        public AxialCoordinate(Vector2<int> position)
          : base(position.X, 0, position.Y) {}

        public override CubeCoordinate ConvertToCube()
        {
            return new CubeCoordinate(Column, -Column - Row, Row);
        }

        public AxialCoordinate Neighbour(HexDirections direction)
        {
            return Add(Directions[direction]);
        }

        public override bool IsCube()
        {
            return false;
        }
    }
}
