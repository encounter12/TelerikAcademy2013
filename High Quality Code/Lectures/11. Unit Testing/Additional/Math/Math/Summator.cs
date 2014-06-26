using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class Summator
    {
        private int a;
        private int b;

        public Summator(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int Sum()
        {
            int sum = this.a + this.b;
            return sum;
        }

        public int A { get; set;}
        public int B { get; set; }
    }
}
