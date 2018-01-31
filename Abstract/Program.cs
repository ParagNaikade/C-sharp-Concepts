using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
1. We cannot create instance of abstract class.
2. Abstract class cannot be sealed or static. 
    Reasons: 
        Static class cannot be marked as abstract, 
because it would be pointless.
             Abstract class makes sense when you want all derived classes 
             to implement same part of the logic. 
             But because static class cannot be derived there is no way other class will implement these gaps.
        Static class cannot be marked sealed because it is made sealed by compiler by default.
If abstract class is derived from sealed, then we cannot derive from that abstarct class, then there is no point of making it abstract.
");

            //// This is not allowed.
            // Car car = new Car();

            Console.ReadKey();
        }
    }

    abstract class Car
    {
        
    }

    public interface ICar
    {
        
    }

    class Bmw
    {
    }
}
