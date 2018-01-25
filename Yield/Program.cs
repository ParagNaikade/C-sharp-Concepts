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
            foreach (var data in GetData())
            {
                Console.WriteLine(data);
            }

            Console.Read();
        }

        private static IEnumerable<int> GetData()
        {
            for (var counter = 0; counter < 1000000; counter++)
            {
                if (counter == 5)
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