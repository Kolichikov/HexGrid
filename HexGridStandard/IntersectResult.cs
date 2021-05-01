using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public class IntersectResult<T>
    {
        public List<T> OnlyFirst;
        public List<T> OnlySecond;
        public List<T> Intersection;

        public IntersectResult()
        {
            OnlyFirst = new List<T>();
            OnlySecond = new List<T>();
            Intersection = new List<T>();
        }

        public IntersectResult(List<T> onlyFirst, List<T> onlySecond, List<T> intersection)
        {
            OnlyFirst = onlyFirst;
            OnlySecond = onlySecond;
            Intersection = intersection;
        }
    }
}
