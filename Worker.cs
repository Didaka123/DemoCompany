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
            IsActive = true;
        }

        public static void AddNewWorker()
        {
            List<string> maleNames = new List<string>() { "Иван", "Димитър", "Георги", "Димитър", "Николай", "Стефан", "Васил", "Христо", "Мартин", "Тодор", "Ангел", "Емил", "Борис", "Асен", "Даниел", "Пламен", "Румен", "Красимир", "Симеон", "Валентин" };
            List<string> maleFamilies = new List<string> { "Иванов", "Петров", "Георгиев", "Димитров", "Николов", "Стефанов", "Василев", "Христов", "Тодоров", "Ангелов", "Стоянов", "Попов", "Колев", "Маринов", "Йорданов", "Павлов", "Илиев", "Добрев", "Антонов", "Симеонов" };
            List<string> femaleNames = new List<string> { "Мария", "Елена", "Йорданка", "Пенка", "Радка", "Росица", "Силвия", "Даниела", "Десислава", "Гергана", "Теодора", "Анелия", "Милена", "Кристина", "Цветелина", "Надежда", "Виктория", "Снежана", "Нина", "Йоана" };
            List<string> femaleFamilies = new List<string> { "Иванова", "Петрова", "Георгиева", "Димитрова", "Николова", "Стефанова", "Василева", "Христова", "Тодорова", "Ангелова", "Стоянова", "Попова", "Колева", "Маринова", "Йорданова", "Павлова", "Илиева", "Добрева", "Антонова", "Симеонова" };
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
            Console.Write("\nВъведете ID на служител за редакция: ");
            int searchId = int.Parse(Console.ReadLine());
            Worker chosenEmployer = null;

            foreach (Worker w in Workers)
            {
                if (w.Id == searchId)
                {
                    chosenEmployer = w;
                    break;
                }
            }

            if (chosenEmployer == null)
            {
                Console.WriteLine("Няма служител с такова ID!");
                return;
            }

            Console.WriteLine($"\nРедакция за: {chosenEmployer.Name} {chosenEmployer.Family}");
            Console.WriteLine("о Редактирай име");
            Console.WriteLine("о Редактирай длъжността (position)");
            Console.WriteLine("о Редактирай заплатата (salary)");
            Console.WriteLine("о Служителят напуска фирмата");
            Console.Write("Изберете опция (въведете име, длъжност, заплата или напускане): ");
            string choice = Console.ReadLine().ToLower();

            if (choice.Contains("име"))
            {
                Console.Write("Въведете ново име: ");
                chosenEmployer.Name = Console.ReadLine();
            }
            else if (choice.Contains("длъжност"))
            {
                Console.Write("Въведете нова длъжност: ");
                chosenEmployer.Position = Console.ReadLine();
            }
            else if (choice.Contains("заплата"))
            {
                Console.Write("Въведете нова заплата: ");
                chosenEmployer.Salary = int.Parse(Console.ReadLine());
            }
            else if (choice.Contains("напускане") || choice.Contains("напуск"))
            {
                chosenEmployer.IsActive = false;
                Console.WriteLine("Служителят беше отбелязан като напуснал (isActive = false).");
            }
            else
            {
                Console.WriteLine("Невалидна опция!");
                return;
            }
            ReadWrite.UpdateStaffFile();
            Console.WriteLine("Данните бяха актуализирани успешно!");
        }

        public static void ActiveWorkersReport()
        {
            Console.WriteLine("\n--- СПИСЪК НА АКТИВНИТЕ СЛУЖИТЕЛИ ---");
            bool hasWorkers = false;

            foreach (Worker w in Workers)
            {
                if (w.IsActive == true)
                {
                    Console.WriteLine($"ID: {w.Id} | {w.Name} {w.Family} | Възраст: {w.Age} | Стаж: {w.Internship} г. | Заплата: {w.Salary} лв. | Длъжност: {w.Position}");
                    hasWorkers = true;
                }
            }

            if (!hasWorkers)
            {
                Console.WriteLine("В момента няма активни служители.");
            }
        }

        public static void InactiveWorkersReport()
        {
            Console.WriteLine("\n--- СПИСЪК НА НАПУСНАЛИТЕ СЛУЖИТЕЛИ ---");
            bool hasWorkers = false;

            foreach (Worker w in Workers)
            {
                if (w.IsActive == false)
                {
                    Console.WriteLine($"ID: {w.Id} | {w.Name} {w.Family} | Последна длъжност: {w.Position}");
                    hasWorkers = true;
                }
            }

            if (!hasWorkers)
            {
                Console.WriteLine("Няма регистрирани напуснали служители.");
            }
        }

        public static void NewYearTransition()
        {
            Console.WriteLine("\nПреминаване в нова година...");

            foreach (Worker w in Workers)
            {
                if (w.IsActive == true)
                {
                    w.Age++;
                    w.Internship++;
                    w.Salary = (int)(w.Salary * 1.05);
                }
            }

            ReadWrite.UpdateStaffFile();
            Console.WriteLine("Успешно преминаване! Стажът е увеличен и заплатите са вдигнати с 5%.");
        }
    }
}

