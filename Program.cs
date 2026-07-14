using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker.Workers = ReadWrite.ReadWorkers();
            Display.Menu();
            //Test comit
        }
    }
}
