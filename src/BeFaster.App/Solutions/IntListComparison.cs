using System.Collections.Generic;

namespace BeFaster.App.Solutions
{
    public class IntListComparison : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            for (var i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode(List<int> obj)
        {
            return obj.GetHashCode();
        }
    }
}