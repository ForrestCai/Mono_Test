using Microsoft.Owin.Hosting;
using System;
using System.Threading;
using Topshelf;

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
            //string baseAddress = "http://*:9000/";
            //var runtime = Type.GetType("Mono.Runtime") != null ? "Mono" : "MS DotNet";

            ////// Start OWIN host 
            //using (WebApp.Start<Startup>(url: baseAddress))
            //{
            //    Console.WriteLine("Service is started on " + runtime + " " + baseAddress);
            //    //Console.ReadLine();
            //    while (true)
            //    {
            //        Thread.Sleep(1);
            //    }
            //}

            //Thread.Sleep(10000);

            HostFactory.Run(c =>
            {
                c.SetServiceName("MonoTestServices");
                c.SetDisplayName("MonoTestServices");
                c.SetDescription("MonoTestServices");

                c.Service<TopshelfService>(s =>
                {
                    s.ConstructUsing(b => new TopshelfService());
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o => o.Stop());
                });
                c.UseLinuxIfAvailable();
                c.RunAsLocalService();
            });

        }
    }
}
