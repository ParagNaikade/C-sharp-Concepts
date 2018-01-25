using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    /// <summary>
    /// C# delegates are similar to pointers to functions, in C or C++. 
    /// With the help of deletgates, methods can be passed as a parameter to another methods.
    /// A delegate is a reference type variable that holds the reference to a method. 
    /// The reference can be changed at runtime.
    /// </summary>
    class Program
    {
        private static int result;

        static void Main(string[] args)
        {
            DoOperations add = new DoOperations(Add);
            Console.WriteLine("Addition: " + add(2, 3));

            DoOperations subtract = Subtract;
            Console.WriteLine("Subtraction: " + subtract(2, 3));

            DoOperations multiply = Multiply;
            Console.WriteLine("Multiplication: " + multiply(2, 3));

            // This is multicast delegate. When delegate is invoked, seris of methods will be invoked.
            // In this case, first Add method and then Multiply method will be invoked.
            add += multiply;

            Console.WriteLine("Addition: " + CallBackMethod(add, 2, 3));
            Console.WriteLine("Subtraction: " + CallBackMethod(subtract, 2, 3));
            Console.WriteLine("Multiplication: " + CallBackMethod(multiply, 2, 3));


            Console.ReadKey();
        }

        // Declaration of deletgate
        delegate int DoOperations(int a, int b);

        static int CallBackMethod(DoOperations doOperations, int a, int b)
        {
            result = doOperations(a, b);

            return result;
        }

        static int Add(int a, int b)
        {
            result = a + b;

            return result;
        }

        static int Multiply(int a, int b)
        {
            result = result * a * b;

            return result;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
