using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async_Await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main thread1: {0}", Thread.CurrentThread.ManagedThreadId);

            // This will cause a deadlock.
            // Accessing the task.Result property will block the Main Thread if task is not complete.
            // https://olitee.com/2015/01/c-async-await-common-deadlock-scenario/
            textBox1.Text = DoSomething().Result;

            Console.WriteLine("Main thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        private async Task<string> DoSomething()
        {
            Console.WriteLine("DoSomething1: {0}", Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(1000);

            return await Task.FromResult("OK");
        }
    }
}
