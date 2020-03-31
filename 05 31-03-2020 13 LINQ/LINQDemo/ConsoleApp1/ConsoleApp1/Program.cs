﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 4, 7, 9, 4, -5, 1 };

            var evens = from num in nums
                        where num % 2 == 0
                        select num;
            nums[4] = 3;
            foreach (var item in evens)
            {
                Console.Write(item + ", ");
            }

            nums[4] = 4;
            var evens2 = (from num in nums
                          where num % 2 == 0
                          select num).ToArray();
            nums[4] = 3;
            Console.WriteLine();
            foreach (var item in evens2)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            var evens3 = nums.Where(x => x % 2 == 0 );
            foreach (var item in evens3)
            {
                Console.Write(item + ", ");
            }

            var myAnounimous = new { Age = 7, Name = "avi" };
            //myAnounimous.Age = 10;

            IEnumerable<int> positives = from x in nums
                                         where x > 0 && x % 2 == 0
                                         select x + 2;
            Console.WriteLine();
            foreach (var item in positives)
            {
                Console.Write(item + ", ");
            }

            string[] names = { "beni", "dana", "zvi", "danny", "daniel", "avi", "danuba", "dan" };
            var short_danies = from name in names
                               where name.StartsWith("dan") && name.Length <= 5
                               select name;
            Console.WriteLine("short_danies:");
            foreach (string item in short_danies)
            {
                Console.WriteLine(item);
            }

            List<Student> myClass = new List<Student>
                {
                    new Student{Id=1, Name="avi", Grade=80},
                    new Student{Id=2, Name="dudu", Grade=50},
                    new Student{Id=3, Name="zvi", Grade=90},
                    new Student{Id=4, Name="beni", Grade=100},
                };

            var students = from student in myClass
                           where student.Grade > 60
                           select student;
            foreach (Student item in students)
            {
                Console.WriteLine(item);
            }


            int[] arr2 = { 1, 3, 5, 7 };
            string[] days = { "none", "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
            var dayName = from x in arr2
                          select new
                          {
                              dayNumber = x,
                              day_name = days[x]
                          };
            foreach (var item in dayName)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in dayName)
            {
                Console.WriteLine(item.dayNumber + ": means " + item.day_name);
            }

            List<Student> ls = Student.CreateClassOfStudents();
            var students2 =
                from student in ls
                where student.Birthdate > new DateTime(2000, 1, 1)
                orderby student.Grade descending
                select new
                {
                    SName = student.Name,
                    SGrade = student.Grade
                };
            //foreach (Student student in students) //ERROR type missmatch!!
            foreach (var student in students2)
            {
                Console.WriteLine("name={0}, grade={1}", student.SName, student.SGrade);
            }
        }
    }




    class myDay
    {
        public int dayNumber { get; set; }
        public string day_name { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Grade { get; set; }
        public DateTime Birthdate { get; set; }
        public byte Age { get; set; }
        public double Hight { get; set; }
        public override string ToString()
        {
            return string.Format("id={0}, name={1}, grade={2}", Id, Name, Grade);
        }

        static public List<Student> CreateClassOfStudents()
        {
            return new List<Student>
            {
                new Student{Id=1, Name="avi", Grade=80, Birthdate=new DateTime(2000,1,27)},
                new Student{Id=2, Name="dudu", Grade=50, Birthdate=new DateTime(1990,7,30)},
                new Student{Id=3, Name="zvi", Grade=90, Birthdate=new DateTime(2005,5,5)},
                new Student{Id=4, Name="beni", Grade=100, Birthdate=new DateTime(1992,11,22)},
            };
        }
    }
}
