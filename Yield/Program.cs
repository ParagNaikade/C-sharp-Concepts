namespace MyProjects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Yield keyword is used when we have a huge collection and we don't need
    /// all items at once. So in this case, we get items one by one and we can do processing on it.
    /// If we want to break this loop, use yield break.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(
                @"Yield keyword is used when we have a huge collection and we don't need all items at once. So in this case, we get items one by one and we can do processing on it. If we want to break this loop, use yield break.");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Following example iterates over 1 million integers and break the loop on 6th integer.");

            Console.WriteLine(Environment.NewLine);

            foreach (var data in GetData())
            {
                Console.WriteLine(data);
            }

            Console.Read();
        }

        private static IEnumerable<int> GetData()
        {
            for (var counter = 1; counter < 1000000; counter++)
            {
                if (counter == 6)
                {
                    // This breaks the loop.
                    yield break;
                }

                //// returns control to caller.

                yield return counter;
            }
        }
    }
}