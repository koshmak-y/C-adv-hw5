using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

/*
 * Тут же и выполнил 5 задание, идентичное этому, только с дополнением:
 * Используйте методы First () / FirstOrDefault (), 
 * OrderBy (), Count () , Min (), Max () и Average ().
 * 
 * Тут же и выполнил 6 задание, идентичное этому, только с дополнением:
 * Выполните операцию Include (), Select (), Find () к данным.
 */


namespace hw3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подождите, происходить создание и заполнение базы... \n");
            using (CodeFirstModel db = new CodeFirstModel())
            {
                Group cAdv = new Group { Name = "C# Advanced" };
                db.Groups.Add(cAdv);
                Group javaAdv = new Group { Name = "Java Advanced" };
                db.Groups.Add(javaAdv);
                db.SaveChanges();

                db.Students.AddRange(new List<Student> { new Student { Age = 20, Name = "Dima", Group = javaAdv },
                    new Student { Age = 18, Name = "Serhiy", Group = javaAdv },
                    new Student { Age = 24, Name = "Armen", Group = javaAdv },
                    new Student { Age = 22, Name = "Igor", Group = javaAdv },
                    new Student { Age = 22, Name = "Egor", Group = cAdv },
                    new Student { Age = 24, Name = "Igor", Group = cAdv } });
                db.SaveChanges();

                Console.WriteLine("Все данные: ");

                foreach (Group group in db.Groups)
                {
                    Console.WriteLine($"В группе {group.Name} учаться:");
                    foreach (Student student in db.Students)
                    {
                        if( student.Group.Name == group.Name)
                        Console.WriteLine("\t" + student.Name + "\tВозраст: " + student.Age);
                    }
                }

                Console.WriteLine("\n\tВызова метода Frist() на каждой из таблиц: ");

                foreach (Group group in db.Groups)
                {
                    Console.WriteLine($"В группе {group.Name} первый студент: {group.StudentsInGroup.First().Name}");
                }

                Console.WriteLine("\n\tВызова метода OrderBy() на каждой из групп: ");

                foreach (Group group in db.Groups)
                {
                    Console.WriteLine($"Группа {group.Name} после сортировки по имени:");
                    var orderby = group.StudentsInGroup.OrderBy(k => k.Name);
                    foreach (var student in orderby)
                    {
                        Console.WriteLine("\t" + student.Name + "\tВозраст: " + student.Age);
                    }
                }

                Console.WriteLine("\n\tВызова метода Count(), Min(), Max(), Avarage() на каждой из групп: ");

                foreach (Group group in db.Groups)
                {
                    int min = group.StudentsInGroup.Min(k => k.Age);
                    int max = group.StudentsInGroup.Max(k => k.Age);
                    double avarage = group.StudentsInGroup.Average(k => k.Age);
                    Console.WriteLine($"В группе {group.Name}: " +
                            $"{group.StudentsInGroup.Count()} человек.");
                    Console.WriteLine($"Из них минимальный возраст - {min}, максимальный - {max}, средний - {(int)avarage}");
                }

                Console.WriteLine("\n\tВыполнение операции Find(): ");

                foreach (Group group in db.Groups)
                {
                    var studentList = (List<Student>)group.StudentsInGroup;
                    Student result = studentList.Find(k => k.Age < 24);
                    Console.WriteLine($"Первый студент в группе { group.Name} меньше 22 лет: {result.Name}");
                }

                Console.ReadKey();
            }
        }
    }
}
