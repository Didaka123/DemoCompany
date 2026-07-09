using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCompany
{
    internal class Worker
    {
        public static List<Worker> Workers = new List<Worker>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
        public int Internship { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }

        public bool IsActive { get; set; }


        public Worker(int id, string name, string family, int age, int internship, int salary, string position)
        {
            Id = id;
            Name = name;
            Family = family;
            Age = age;
            Internship = internship;
            Salary = salary;
            Position = position;
        }

        public static void AddNewWorker()
        {
            List<string> maleNames = new List<string>() { "Иван", "Димитър", "Георги", "Димитър", "Николай", "Стефан", "Васил", "Христо", "Мартин", "Тодор", "Ангел", "Емил", "Броис", "Асен", "Даниел", "Пламен", "Румен", "Красимир", "Симеон", "Валентин" };
            List<string> maleFamilies = new List<string> { "Иванов", "Петров", "Георгиев", "Димитров", "Николов", "Стефанов", "Василев", "Христов", "Тодоров", "Ангелов", "Стоянов", "Попов", "Колев", "Маринов", "Йорданов", "Павлов", "Илиев", "Добрев", "Антонов", "Симеонов" };
            List<string> femaleNames = new List<string> { "Мария", "Елена", "Йорданка", "Пенка", "Радка", "Росица", "Силвия", "Даниела", "Десислава", "Гергана", "Теодора", "Анелия", "Милена", "Кристина", "Цветелина", "Надежда", "Виктория", "Снежана", "Нина", "Йоана" };
            List<string> femaleFamilies = new List<string> { "Иванова", "Петрова", "Георгиева", "Димитрова", "Николова", "Стефанова", "Василева", "Христова", "Тодорова", "Ангелова", "Стоянова", "Попова", "Колева", "Маринов", "Йорданов", "Павлов", "Илиева", "Добрева", "Антонова", "Симеонова" };
            Random rand = new Random();
            string[] candNames = new string[5];
            string[] candFamilies = new string[5];
            int[] candAges = new int[5];

            Console.WriteLine("\n=== Списък с 5 случайни кандидати ===");
            for (int i = 0; i < 5; i++)
            {
                int gender = rand.Next(0, 2); 

                if (gender == 0)
                {
                    candNames[i] = maleNames[rand.Next(0, 20)];
                    candFamilies[i] = maleFamilies[rand.Next(0, 20)];
                }
                else
                {
                    candNames[i] = femaleNames[rand.Next(0, 20)];
                    candFamilies[i] = femaleFamilies[rand.Next(0, 20)];
                }

                candAges[i] = rand.Next(20, 56); 

                Console.WriteLine((i + 1) + ") " + candNames[i] + " " + candFamilies[i] + ", Възраст: " + candAges[i]);
            }

            Console.Write("\nИзберете кандидат (1-5): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > 5)
            {
                Console.WriteLine("Невалиден избор!");
                return;
            }

            string chosenName = candNames[choice - 1];
            string chosenFamily = candFamilies[choice - 1];
            int chosenAge = candAges[choice - 1];

            Console.Write("Въведете длъжност: ");
            string position = Console.ReadLine();

            Console.Write("Въведете заплата: ");
            int salary = int.Parse(Console.ReadLine());
            int nextId = 1;
            if (Workers.Count > 0)
            {
                nextId = Workers[Workers.Count - 1].Id + 1;
            }
            Worker newWorker = new Worker(nextId, chosenName, chosenFamily, chosenAge, 0, salary, position);
            newWorker.IsActive = true; 
            Workers.Add(newWorker);
            ReadWrite.UpdateStaffFile();

            Console.WriteLine("Служителят е назначен успешно!");
        }

        public static void EditWorkersData()
        {

        }

        public static void ActiveWorkersReport()
        {
        }

        public static void InactiveWorkersReport()
        {
        }
    }
}
