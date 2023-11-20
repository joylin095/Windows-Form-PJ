using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class MockRandomGenerator : IRandom
    {
        const int VALUE = 200;
        // random
        public int GetNext(int low, int high)
        {
            return VALUE;
        }
    }
}
