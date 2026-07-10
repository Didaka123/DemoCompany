using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCompany
{
    internal class Display
    {
       public static void Menu ()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n=== Моля изберете ===");
            Console.ResetColor();

            Console.WriteLine("1) Добави нов служител");
            Console.WriteLine("2) Редактирай данни за служител");
            Console.WriteLine("3) Справка за активните служители");
            Console.WriteLine("4) Справка за напусналите служители ");
            Console.WriteLine("5) Преминаване в нова година ");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Вашият избор:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            int choose = int.Parse(Console.ReadLine());
            Console.ResetColor();

            switch (choose)
            {
                case 1: Worker.AddNewWorker(); break;
                case 2: Worker.EditWorkersData(); break;
                case 3: Worker.ActiveWorkersReport(); break;
                case 4: Worker.InactiveWorkersReport(); break;
                case 5: Worker.NewYearTransition(); break;
                default: Environment.Exit(0); break;
            }

            Menu();

        }


    }
}
