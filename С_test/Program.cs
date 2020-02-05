using System;
using Card_ns;
using Profession_ns;
using System.Collections.Generic;
namespace С_test
{
    class Person : ICloneable
    {
        public static int ID = 0;
        public int age { get; }
        public string name { get; }
        public string sex { get; }
        public Card per_card;
        public Profession per_prof;
       
        public Person(int age , string name , string sex) {
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
                var person = (Person ) MemberwiseClone();
            return person;
                 
        }
    }


   

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> pers_arr = new List<Person>() ;
            Console.WriteLine("Create new Hero ;)");
            Console.WriteLine("What are you want ?");
            Console.WriteLine(" 1 : Create new person \n 2 : Compare person \n 3 : Show all peoples\n 4 : Read file 5 : Write in file \n 6 : Exit \n Enter number of option : ");
            int ex = 1;
            while (ex!=0) {
                Console.WriteLine("Enter choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Creater(ref pers_arr);
                        break;
                    case 2:
                        ShowInfo(ref pers_arr);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
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

            Console.WriteLine($" name : {pers_arr[0].name} \n sex : {pers_arr[0].sex} \n age : {pers_arr[0].age}     \n type of card : {pers_arr[0].per_card.type} \n number of card : {pers_arr[0].per_card.number} \n type of work : {pers_arr[0].per_prof.type_work} \n experience : {pers_arr[0].per_prof.exp} \n salary : {pers_arr[0].per_prof.salary}");

        }

        static void Creater(ref List<Person>  arr)
        {
            Console.WriteLine("Enter name : ");
            string tmp_name = Console.ReadLine();
            Console.WriteLine("Enter sex : ");
            string tmp_sex = Console.ReadLine();
            Console.WriteLine("Enter age : ");
            int tmp_age = Convert.ToInt32(Console.ReadLine());
            Person tmp = new Person(tmp_age , tmp_name , tmp_sex);
            tmp.per_card = new Card();
            Console.WriteLine("Enter type of card \n 1 - medic card \n 2 - social card ");
            int type_card = Convert.ToInt32(Console.ReadLine());
            tmp.per_card.type = type_card;
            Console.WriteLine("Enter number of card (4 numberf XX_XX)");
            int tmp_num = Convert.ToInt32(Console.ReadLine());
            tmp.per_card.number = tmp_num;
            //---------------------PROFESION----------------------//
            Console.WriteLine("Enter some about job");
            Console.WriteLine("Enter type of work");
            string tmp_type_work = Console.ReadLine();
            Console.WriteLine("Enter experience of work");
            int exp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your salary ");
            int salary = Convert.ToInt32(Console.ReadLine());
            tmp.per_prof = new Profession(tmp_type_work, exp, salary);
            arr.Add(tmp);
            
        }
    }
    
}
