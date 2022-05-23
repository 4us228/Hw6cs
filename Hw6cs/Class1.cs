using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw6cs
{
    internal class Class1
    {
        class Student
        {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;
            // Создаем конструктор
            public Student(string firstName, string lastName, string university,
            string faculty, string department,int age, int course, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }
        }
        static int MyDelegat(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);

        }
      

      
        static void Main(string[] args)
        {
            int studentOnFifthCourse = 0;
            int studentOnSixthCourse = 0;
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();
            // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_6.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new
                    Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров

                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++; //Ошибка методички, в файле под этим индексом стоит возраст 
                   
                    
                    //Задание 3.А
                    if (int.Parse(s[6]) == 6) studentOnSixthCourse++;
                    if (int.Parse(s[6]) == 5) studentOnFifthCourse++;
                    


                 


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");

                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));

            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
           
            
            
            Console.WriteLine($"Студентов на 5 курсе: {studentOnFifthCourse} и на шестом: {studentOnSixthCourse}");
            List<Student> studentsInfo = new List<Student>();
            
            

          //Задание 2.Б
                foreach (Student student in list) 
                {
                    if (student.age>=18 && student.age <=20) studentsInfo.Add(student);

                    
                }
               
                Console.WriteLine($"Количество студентов в возрасте от 18 до 20 лет : {studentsInfo.Count}");
            foreach (Student student in studentsInfo) Console.WriteLine($"Возраст студента {student.age} лет, курс на котором учится студент {student.course} курс");
 

            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();

        }
    }
}



  

