namespace hw3
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class CodeFirstModel : DbContext
    {
        // Контекст настроен для использования строки подключения "CodeFirstModel" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "hw3.CodeFirstModel" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "CodeFirstModel" 
        // в файле конфигурации приложения.
        public CodeFirstModel()
            : base("name=CodeFirst")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }    
        public int? GroupId { get; set; }
        public Group Group{ get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> StudentsInGroup { get; set; }
        public Group()
        {
            StudentsInGroup = new List<Student>();
        }
    }
}