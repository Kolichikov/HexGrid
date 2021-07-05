using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexGridStandard
{
    public class HexGrid<T> where T : Coordinate, new()
    {
        public List<T> Ring<TOutput>(int radius, T center, Func<List<T>, TOutput> interaction)
        {
            throw new NotImplementedException();
        }

        public List<T> Ring<TOutput>(int radius, T center, Func<T, TOutput> interaction)
        {
            throw new NotImplementedException();
        }

        public List<T> Ring(int radius, T center)
        {
            if (radius < 1)
                throw new ArgumentOutOfRangeException(nameof(radius), "Can't have zero or negative radius");
            var objList1 = new List<T>();
            var direction1 = CubeCoordinate.Directions[HexDirections.BottomLeft];
            direction1.Position = new Vector3(direction1.Position.X * radius, direction1.Position.Y * radius, direction1.Position.Z * radius);
            var cubeCoordinate = center.Add(direction1);
            for (var direction2 = 0; direction2 < 6; ++direction2)
            {
                for (var index = 0; index < radius; ++index)
                {
                    var objList2 = objList1;
                    var obj = new T();
                    obj.Position = new Vector3(cubeCoordinate.Position.X, cubeCoordinate.Position.Y, cubeCoordinate.Position.Z);
                    objList2.Add(obj);
                    cubeCoordinate = cubeCoordinate.Neighbour(direction2);
                }
            }
            return objList1;
        }

        public bool OnRing(T inTest, int radius, T centre)
        {
            if (radius < 1)
                throw new ArgumentOutOfRangeException(nameof(radius), "Can't have zero or negative radius");

            var xDiff = Math.Abs(centre.Position.X - inTest.Position.X);
            var yDiff = Math.Abs(centre.Position.Y - inTest.Position.Y);
            var zDiff = Math.Abs(centre.Position.Z - inTest.Position.Z);

            return Math.Max(zDiff, Math.Max(xDiff, yDiff)) == radius;
        }

        public bool OnRing(Vector3 inTest, int radius, Vector3 centre)
        {
            if (radius < 1)
                throw new ArgumentOutOfRangeException(nameof(radius), "Can't have zero or negative radius");

            var xDiff = Math.Abs(centre.X - inTest.X);
            var yDiff = Math.Abs(centre.Y - inTest.Y);
            var zDiff = Math.Abs(centre.Z - inTest.Z);

            return Math.Max(zDiff, Math.Max(xDiff, yDiff)) == radius;
        }


        public List<T> Range(int range, T center, Action<T> inCompilationAction = null)
        {
            var objList = new List<T>();
            for (var index1 = -range; index1 <= range; ++index1)
            {
                for (var index2 = Math.Max(-range, -index1 - range); index2 <= Math.Min(range, -index1 + range); ++index2)
                {
                    var num = -index1 - index2;
                    var obj1 = new T();
                    obj1.Position = new Vector3(index1, index2, num);
                    var obj2 = obj1.Add(center);
                    objList.Add(obj2);
                    inCompilationAction?.Invoke(obj2);
                }
            }
            return objList;
        }

        public IntersectResult<T> Intersect(List<T> first, List<T> second)
        {
            var intersectResult = new IntersectResult<T>();
            intersectResult.OnlySecond = new List<T>(second);
            foreach (var obj1 in first)
            {
                var flag = false;
                foreach (var obj2 in intersectResult.OnlySecond.Where(obj2 => obj1.Position.Equals(obj2.Position)))
                {
                    intersectResult.Intersection.Add(obj1);
                    intersectResult.OnlySecond.Remove(obj2);
                    flag = true;
                    break;
                }
                if (!flag)
                    intersectResult.OnlyFirst.Add(obj1);
            }
            return intersectResult;
        }

        public List<T> Line(T start, T finish)
        {
            var num = start.Distance(finish);
            var objList = new List<T>();
            for (var index = 0; (double)index <= (double)num; ++index)
                objList.Add(Lerp(start.ConvertToCube(), finish.ConvertToCube(), 1f / num * index));
            return objList;
        }

        private static T Lerp(Coordinate a, Coordinate b, float t)
        {
            var obj = new T();
            obj.Position = new Vector3((int)Math.Floor(Lerp(a.Position.X, b.Position.X, t))
                , (int)Math.Floor(Lerp(a.Position.Y, b.Position.Y, t))
                , (int)Math.Floor(Lerp(a.Position.Z, b.Position.Z, t)));
            return obj;
        }

        public static float Lerp(float start, float finish, float amount)
        {
            return start + (finish - start) * amount;
        }
    }
}
