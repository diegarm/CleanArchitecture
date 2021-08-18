using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;

            //Create an assembly called CustomLibrary to run this sample.
            currentDomain.Load("Clean.Api");

            //Make an array for the list of assemblies.
            Assembly[] assems = currentDomain.GetAssemblies();

            //List the assemblies in the current application domain.
            Console.WriteLine("List of assemblies loaded in current appdomain:");
            foreach (Assembly assem in assems)
                Console.WriteLine(assem.ToString());
        }
    }
}
