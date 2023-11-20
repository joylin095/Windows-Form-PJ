using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public interface IRandom 
    {
        // random
        int GetNext(int low, int high);
    }
}
