using System;
using Card_ns;
using Profession_ns;
using System.Collections.Generic;
namespace С_test
{
    class Person : ICloneable, IComparable
    {
        public static int ID = 0;
        public int age { get; }
        public string name { get; }
        public string sex { get; }
        public Card per_card;
        public Profession per_prof;

        public Person(int age, string name, string sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
            ID++;
        }
        public Person()
        {
            ID++;
        }
        public object Clone()
        {
            Person clone_pers = new Person(this.age, this.name, this.sex);
            clone_pers.per_prof = new Profession(this.per_prof.type_work, this.per_prof.exp, this.per_prof.salary);
            clone_pers.per_card = new Card();
            clone_pers.per_card.type = this.per_card.type;
            clone_pers.per_card.number = this.per_card.number;

            return clone_pers;

        }
        public int CompareTo(object sec)
        {
            Person second = sec as Person;
            if (this.name == second.name)
            { Console.WriteLine($"Names : {this.name }  |  {second.name }   +"); }
            else { Console.WriteLine($"Names : {this.name }  |  {second.name }   -"); }
            if (this.age == second.age)
            { Console.WriteLine($"Age : {this.age }  |  {second.age }   +"); }
            else { Console.WriteLine($"Age : {this.age }  |  {second.age }   -"); }
            if (this.sex == second.sex)
            { Console.WriteLine($"Sex : {this.sex }  |  {second.sex }   +"); }
            else { Console.WriteLine($"Sex : {this.sex }  |  {second.sex }   -"); }
            if (this.per_card.type == second.per_card.type)
            { Console.WriteLine($"Card type : {this.per_card.type }  |  {second.per_card.type }   +"); }
            else { Console.WriteLine($"Card type : {this.per_card.type }  |  {second.per_card.type }   -"); }
            if (this.per_card.number == second.per_card.number)
            { Console.WriteLine($"Card number : {this.per_card.number }  |  {second.per_card.number }   +"); }
            else
            { Console.WriteLine($"Card number : {this.per_card.number }  |  {second.per_card.number }   -"); }
            return 0;
        }

        public void IdCounte()
        {
            Console.WriteLine($"Counet ID : {ID}");
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            List<Person> pers_arr = new List<Person>();
            Console.WriteLine("Create new Hero ;)");
            Console.WriteLine("What are you want ?");
            int ex = 1;
            while (ex != 0)
            {
                Console.Write("\n 1 : Create new person \n 2 : Compare person \n 3 : ----\n 4 : Read file\n 5 : Write in file \n 6 : Show all person  \n 7 : Show short info  \n 8 : exit \nEnter number of option : ");


                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Creater(ref pers_arr);
                        break;
                    case 2:
                        ShowCompare(ref pers_arr);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
                        ShowInfo(ref pers_arr);
                        break;
                    case 7:
                        ShowShortInfo(ref pers_arr);
                        break;
                    case 8:
                        ex = 0;
                        break;
                    default:
                        Console.WriteLine("Bye");
                        break;
                }

            }
        }
        static void ShowInfo(ref List<Person> pers_arr)
        {
            foreach (Person tmp in pers_arr)
            {
                Console.WriteLine($"\n name : {tmp.name} \n sex : {tmp.sex} \n age : {tmp.age}     \n type of card : {tmp.per_card.type} \n number of card : {tmp.per_card.number} \n type of work : {tmp.per_prof.type_work} \n experience : {tmp.per_prof.exp} \n salary : {tmp.per_prof.salary}");
            }
        }
        static void ShowShortInfo(ref List<Person> pers_arr)
        {
            foreach (Person tmp in pers_arr)
            {
                Console.WriteLine($"\n name : {tmp.name} \n sex : {tmp.sex} \n age : {tmp.age}");
            }
        }

        static void Creater(ref List<Person> arr)
        {
            Console.Write("Enter name : ");
            string tmp_name = Console.ReadLine();
            Console.Write("Enter sex : ");
            string tmp_sex = Console.ReadLine();
            Console.Write("Enter age : ");
            int tmp_age = Convert.ToInt32(Console.ReadLine());
            Person tmp = new Person(tmp_age, tmp_name, tmp_sex);
            tmp.per_card = new Card();
            Console.WriteLine("Enter type of card \n 1 - medic card \n 2 - social card ");
            int type_card = Convert.ToInt32(Console.ReadLine());
            tmp.per_card.type = type_card;
            Console.Write("Enter number of card (4 numberf XX_XX) : ");
            int tmp_num = Convert.ToInt32(Console.ReadLine());
            tmp.per_card.number = tmp_num;
            //---------------------PROFESION----------------------//
            Console.WriteLine("Enter some about job");
            Console.Write("Enter type of work : ");
            string tmp_type_work = Console.ReadLine();
            Console.Write("Enter experience of work : ");
            int exp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            tmp.per_prof = new Profession(tmp_type_work, exp, salary);

            //  deep clone is working ; 
            // Person test_clone_method = (Person)tmp.Clone();  
            arr.Add(tmp);

        }

        static void ShowCompare(ref List<Person> arr)
        {
            int first, second;
            Console.WriteLine("Which member you want to compare ?");
            Console.Write("Fitsr : ");
            first = Convert.ToInt32(Console.ReadLine());
            Console.Write("Second : ");
            second = Convert.ToInt32(Console.ReadLine());
            arr[first].CompareTo(arr[second]);
        }
    }

}
