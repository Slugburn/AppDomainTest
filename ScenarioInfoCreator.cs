using System;
using System.Reflection;
using PPA.ScenarioData2;

namespace AppDomainTest
{
    public class ScenarioInfoCreator : MarshalByRefObject
    {
        public void Create(string solverName, int scenarioId)
        {
            var assembly = Assembly.LoadFrom(string.Format(@"..\..\..\TestSolver\bin\debug\{0}.dll", solverName));
            var solver = (IScenarioSolver) assembly.CreateInstance("TestSolver.MySolver");
            Console.WriteLine("Creating scenario {0} in AppDomain {1}", scenarioId, AppDomain.CurrentDomain.FriendlyName);
            var info = new ScenarioInfo();
            foreach (var aug in solver.GetAugmenters())
            {
                aug.Augment(info, null);
            }
            Console.WriteLine(info.Properties.Stuff);
        }
    }
}
