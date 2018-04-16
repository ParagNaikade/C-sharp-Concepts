namespace MyProjects
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Serialization is a process where we can convert an object state 
    /// in to stream of bytes. This stream can then be persisted in a file,database, 
    /// or sent over a network etc.  
    /// Deserialization is just vice-versa of serialization 
    /// where we convert stream of bytes back to the original object.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Customer obj = new Customer
            {
                Id = 123,
                Name = "Jane Doe"
            }; // Create object

            Serialize(obj);

            var customer = Deserialize();

            Console.WriteLine(customer.Id + "...." + customer.Name);

            Console.Read();
        }

        private static void Serialize(Customer customer)
        {
            IFormatter formatter = new BinaryFormatter();
            {
                Stream stream = new FileStream(@"C:\temp\MyFile.txt", FileMode.Create, FileAccess.Write, FileShare.None);

                formatter.Serialize(stream, customer); // write it to the file

                stream.Close(); // Close the stream
            }
        }

        private static Customer Deserialize()
        {
            IFormatter formatter = new BinaryFormatter(); // Use binary formatter
            var stream = new FileStream(@"C:\temp\MyFile.txt", FileMode.Open, FileAccess.Read, FileShare.Read); // read the file

            Customer customer = (Customer)formatter.Deserialize(stream); // take data back to object

            stream.Close(); // close the stream

            return customer;
        }

        [Serializable]
        class Customer
        {
            public string Name { get; set; }

            public int Id { get; set; }
        }
    }
}