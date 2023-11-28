using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice
{
    public class RandomGenerator : IRandom
    {
        Random _random = new Random();

        //random
        public int GetNext(int low, int high)
        {
            return _random.Next(low, high);
        }
    }
}
