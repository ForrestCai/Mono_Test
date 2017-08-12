using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mono_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task.Factory.StartNew(()=> { Console.WriteLine("Hello Word!" + Thread.CurrentThread.ManagedThreadId); });

            //Task.Factory.StartNew(() => { Console.WriteLine("Hello Word!" + Thread.CurrentThread.ManagedThreadId); });

            //Task.Factory.StartNew(() => { Console.WriteLine("Hello Word!" + Thread.CurrentThread.ManagedThreadId); });

            //Console.ReadKey();
            string baseAddress = "http://localhost:9000/";
            var runtime = Type.GetType("Mono.Runtime") != null ? "Mono" : "MS DotNet";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Service is started on " + runtime);
                Console.ReadLine();
            }
        }
    }
}
