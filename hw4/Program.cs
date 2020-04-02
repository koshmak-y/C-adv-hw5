using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подождите, происходить создание и заполнение базы... \n");
            using (CodeFirst db = new CodeFirst())
            {
                Job j1 = new Job() { Name = "Uni"};
                Job j2 = new Job() { Name = "SoftComp" };
                db.Jobs.Add(j1);
                db.Jobs.Add(j1);

                Employee e1 = new Employee() { Name = "Egor", Experience = 2 };
                Employee e2 = new Employee() { Name = "Dima", Experience = 3 };

                j1.Employees.Add(e1);
                j1.Employees.Add(e2);
                j2.Employees.Add(e2);
                e1.Jobs.Add(j2);

                db.SaveChanges();
                foreach (var job in db.Jobs)
                {
                    Console.WriteLine($"Имя компании: {job.Name}. Список работников:");
                    foreach (var employee in job.Employees)
                    {
                        Console.WriteLine($"\t- {employee.Name}, стаж - {employee.Experience}");
                    }
                }
            }
            Console.WriteLine("Готово.");
            Console.ReadKey();
        }
    }
}
