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
