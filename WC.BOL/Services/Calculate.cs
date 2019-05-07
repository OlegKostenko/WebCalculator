using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.BOL.Services
{
    public class Calculate : ICalculate
    {
        public double Addition(double a, double b)
        {
            return a + b;
        }

        public double Division(double a, double b)
        {
            if (b == 0)
                throw new NotImplementedException();
            else
                return a / b;
        }

        public double Exponentiation(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public double Multiplication(double a, double b)
        {
            return a * b;
        }

        public double Subtraction(double a, double b)
        {
            return a - b;
        }
    }
}
