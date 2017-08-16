using Microsoft.Owin.Hosting;
using System;

namespace Mono_Test
{
    public class TopshelfService
    {
        public void Start()
        {
            string baseAddress = "http://*:9000/";
            //var runtime = Type.GetType("Mono.Runtime") != null ? "Mono" : "MS DotNet";
            //Console.WriteLine("Service is started on " + runtime + " " + baseAddress);
            WebApp.Start<Startup>(url: baseAddress);
        }

        public void Stop()
        {
        }
    }
}
