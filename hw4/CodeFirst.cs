namespace hw4
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class CodeFirst : DbContext
    {
        // Контекст настроен для использования строки подключения "CodeFirst" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "hw4.CodeFirst" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "CodeFirst" 
        // в файле конфигурации приложения.
        public CodeFirst()
            : base("name=CodeFirst")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public Job()
        {
            Employees = new List<Employee>();
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }

        public ICollection<Job> Jobs { get; set; }
        public Employee()
        {
            Jobs = new List<Job>();
        }
    }
}