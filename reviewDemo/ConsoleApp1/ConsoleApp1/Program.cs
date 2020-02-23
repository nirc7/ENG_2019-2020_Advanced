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


            Dog d = new Dog(12, "DoogyDog", true);
            d.MakeSound();

            IMakeSound[] ims = new IMakeSound[] {
                new Person(){ Name="avi", ID=7},
                new Dog(7,"asd",false)
             };

            foreach (var mk in ims)
            {
                mk.MakeSound();
            }

            //if (ims[0] is Dog)
            //{
            //    ((Dog)ims[0]).HasBone = true;
            //    ((Dog)ims[0]).??? = true;
            //    ((Dog)ims[0]).??? = true;
            //}

            //Dog d2 = ims[0] as Dog;
            //if (d2 != null)
            //{
            //    d2.HasBone = true;
            //}

        }
    }

    class Person : IMakeSound
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Person()
        {

        }

        public Person(int i, string n)
        {
            Name = n;
            ID = i;
        }

        public override string ToString()
        {
            return $"{ID},{ Name}";
        }

        public void MakeSound()
        {
            Utils.PlaySound( "person.wav");
        }
    }

    abstract class Animal : Object, IComparable, IMakeSound
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

        public virtual void MakeSound()
        {
           Utils.PlaySound( "animal.wav");
        }
    }

    class Dog : Animal, IMakeSound
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

        public override void MakeSound()
        {
            Utils.PlaySound("dog.wav");
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

    public static class Utils
    {
        public static void PlaySound(string path)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = path;
            player.PlaySync();
        }
    }
}
