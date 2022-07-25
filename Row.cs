using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productivity_controller
{
    public class Row
    {
        public DateTime date;
        public int productivity;
        public int mood;

        public Row(DateTime d, int p, int m)
        {
            date = d;
            productivity = p;
            mood = m;
        }
    }
}
