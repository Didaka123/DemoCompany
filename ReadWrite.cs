using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DemoCompany
{
    internal class ReadWrite
    {

        private static string filePath = @"..\..\Data\staff.txt";
        public static void UpdateStaffFile()
        {
            List<string> lines = new List<string>();
            foreach (Worker w in Worker.Workers)
            {
                string line = w.Id + "," + w.Name + "," + w.Family + "," + w.Age + "," + w.Internship + "," + w.Salary + "," + w.Position + "," + w.IsActive;
                lines.Add(line);
            }
            File.WriteAllLines(filePath, lines);

        }
        public static List<Worker> ReadWorkers()
        {
            List<Worker>list = new List<Worker>();
            if (!File.Exists(filePath))
            {
                return list;
            }
            string[]lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line == "") continue; 

                
                string[] parts = line.Split(',');

                int id = int.Parse(parts[0]);
                string name = parts[1];
                string family = parts[2];
                int age = int.Parse(parts[3]);
                int internship = int.Parse(parts[4]);
                int salary = int.Parse(parts[5]);
                string position = parts[6];
                bool isActive = bool.Parse(parts[7]);
                Worker w = new Worker(id,name , family, age, internship,salary , position);
                w.IsActive= isActive;
                list.Add(w);
                
            }
            return list;
        }
    }
}
