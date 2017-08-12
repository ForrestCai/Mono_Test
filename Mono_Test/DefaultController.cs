using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Threading;

namespace Mono_Test
{
    public class DefaultController : ApiController
    {
        private readonly IService _service;
        private object _syncObject = new object();
        private Semaphore sm = new Semaphore(2, 2);

        public DefaultController(IService service)
        {
            _service = service;
        }

        public string Get()
        {
            var reault = string.Empty;

            var book = new Workbook("./Test.xlsx");
            var sheet = book.Worksheets[0];
            sheet.Cells["A1"].Value = 7;
            sheet.Cells["A2"].Value = 8;

            book.CalculateFormula();

            reault = sheet.Cells["A3"].Value.ToString();

            return _service.GetMessage() + " hello world! " + reault;
        }

        [HttpGet]
        public string TestLock()
        {
            Task.Factory.StartNew(Lock);

            Task.Factory.StartNew(Lock);

            Console.WriteLine("Request Hello Word!" + Thread.CurrentThread.ManagedThreadId);

            return "Lock OK";
        }

        [HttpGet]
        public string TestSemaphore()
        {
            Task.Factory.StartNew(Semaphore);
            Task.Factory.StartNew(Semaphore);
            Task.Factory.StartNew(Semaphore);
            Task.Factory.StartNew(Semaphore);

            Console.WriteLine("Request Hello Word!" + Thread.CurrentThread.ManagedThreadId);
            return "Lock OK";
        }

        private void Lock()
        {
            lock (_syncObject)
            {
                Thread.Sleep(5000);
                Console.WriteLine("Hello Word!" + Thread.CurrentThread.ManagedThreadId);
            }
        }

        private void Semaphore()
        {
            sm.WaitOne(10000);

            Thread.Sleep(5000);
            Console.WriteLine("Hello Word!" + Thread.CurrentThread.ManagedThreadId);

            sm.Release();
        }
    }
}
