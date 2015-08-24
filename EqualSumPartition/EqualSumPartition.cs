using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumPartition
{
    public sealed class EqualSumPartition
    {
        int[] _values;
        bool[] _isUsed;
        int P;
        int sum = 0;
        List<List<int>> box = new List<List<int>>();


        public List<List<int>> Calculate(int[] data, int p)
        {
            _values = data;
            P = p;

            _isUsed = new bool[data.Length];

            Array.Sort(_values, (x, y) => (y - x));

            box.Clear();

            // Initialize boxes
            for (int i = 0; i < P; i++)
                box.Add(new List<int>());

            // Sum of the values
            sum = _values.Sum();

            // For each box
            for (int i = 0; i < P; i++)
            {
                int m = sum / (P - i);
                FillBox(box[i], m);
            }

            return box;
        }


        private void FillBox(List<int> box, int m)
        {
            var b = BiggestValueIndex();

            if (b == -1) throw new Exception("You sould not see this");

            box.Add(_values[b]);
            _isUsed[b] = true;

            if (_values[b] >= m)
                goto devamEt;

            b = BiggestValueIndex();

            while (b != -1)
            {
                var v = _values[b];

                if ((box.Sum() + v) > m)
                {
                    goto devam;
                }

                box.Add(v);
                _isUsed[b] = true;

            devam:
                b = NextBiggestValueIndex(b);
            }

        devamEt:
            sum = sum - box.Sum();
        }

        private int NextBiggestValueIndex(int current)
        {
            for (int i = current + 1; i < _values.Length; i++)
            {
                if (!_isUsed[i])
                {
                    return i;
                }

            }

            return -1;
        }

        private int BiggestValueIndex()
        {
            for (int i = 0; i < _values.Length; i++)
            {
                if (!_isUsed[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
