using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDomain = AppDomain.CreateDomain("TestDomain");
            var creator = (ScenarioInfoCreator)appDomain.CreateInstanceAndUnwrap("AppDomainTest", "AppDomainTest.ScenarioInfoCreator");
            creator.Create("TestSolver",1);
            AppDomain.Unload(appDomain);
            Console.ReadKey();
        }
    }
}
