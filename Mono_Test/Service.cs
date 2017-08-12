using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Test
{
    public class Service : IService
    {
        public string GetMessage()
        {
            return "From Service";
        }
    }
}
