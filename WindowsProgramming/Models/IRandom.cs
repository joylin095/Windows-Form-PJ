using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPractice
{
    public interface IRandom 
    {
        // random
        int GetNext(int low, int high);
    }
}
