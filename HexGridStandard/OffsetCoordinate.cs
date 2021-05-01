using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public class OffsetCoordinate : Coordinate
    {
        public int Row => Position.Y;

        public int Column => Position.X;

        public OffsetType Offset { get; }

        public OffsetCoordinate(OffsetType type)
        {
            Offset = type;
        }

        public override bool IsCube()
        {
            return false;
        }
        public OffsetCoordinate(OffsetType type, int column, int row)
          : base(column, row, 0)
        {
            Offset = type;
        }

        public OffsetCoordinate(Vector2<int> position)
          : base(position.X, position.Y, 0)
        {
        }

        public override CubeCoordinate ConvertToCube()
        {
            int x;
            int z;
            int y;
            switch (Offset)
            {
                case OffsetType.OddRow:
                    x = Column - (int)((Row - (double)((int)Row & 1)) / 2.0);
                    z = Row;
                    y = -x - z;
                    break;
                case OffsetType.EvenRow:
                    x = Column - (int)((Row + (double)((int)Row & 1)) / 2.0);
                    z = Row;
                    y = -x - z;
                    break;
                case OffsetType.OddColumn:
                    x = Column;
                    z = Row - (int)((Column - (double)((int)Column & 1)) / 2.0);
                    y = -x - z;
                    break;
                case OffsetType.EvenColumn:
                    x = Column;
                    z = Row - (int)((Column + (double)((int)Column & 1)) / 2.0);
                    y = -x - z;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Offset), "Invalid Offset type detected");
            }
            return new CubeCoordinate(x, y, z);
        }
    }
}
