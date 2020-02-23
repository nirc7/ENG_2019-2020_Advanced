using System;
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
            Animal[] animals = new Animal[]
                {
                    new Dog(15,"Snoopy",false),
                    new Cat(7, "mitzi",true ),
                    new Dog (12, "DoogyDog", true)
                };


            foreach (var ani in animals)
            {
                Console.WriteLine(ani);
            }

            Array.Sort(animals);
            foreach (var ani in animals)
            {
                Console.WriteLine(ani);
            }



            int[] nums = new int[] { 2, 7, 4, 8, 2, 9, 1 };

            foreach (var num in nums)
            {
                Console.Write(num + ", ");
            }
            Console.WriteLine();
            Array.Sort(nums);
            foreach (var num in nums)
            {
                Console.Write(num + ", ");
            }

        }
    }

    abstract class Animal : Object, IComparable
    {
        public int Weight { get; set; }
        public string Name { get; set; }

        public Animal(int w, string n)
        {
            Weight = w;
            Name = n;
        }

        public abstract void Eat();

        public int CompareTo(object obj)
        {
            return Weight - ((Animal)obj).Weight;
        }
    }

    class Dog : Animal
    {
        public bool HasBone { get; set; }

        public Dog(int w, string n, bool hb) : base(w, n)
        {
            HasBone = hb;
        }

        public override void Eat()
        {
            Weight += 5;
        }

        public override string ToString()
        {
            return $"{Name},{Weight}, does{(HasBone ? " " : " not ")}have a bone";
        }
    }

    class Cat : Animal
    {
        public bool HasBall { get; set; }
        public Cat(int w, string n, bool hb) : base(w, n)
        {
            HasBall = hb;
        }

        public override void Eat()
        {
            Weight++;
        }

        public override string ToString()
        {
            return $"{Name},{Weight},does{(HasBall ? " " : " not ")}have a ball";
        }
    }

    public interface IMakeSound
    {
         void MakeSound();
    }
}
