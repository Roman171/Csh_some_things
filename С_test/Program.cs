using System;
using Card_ns;
using Profession_ns;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace С_test

{

    [Serializable]
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
        static BinaryFormatter formatter = new BinaryFormatter();
        static string[] linq_example = { "123", "qwerty ", "11111111", "1" , "qqqqqq"};

        static void Main(string[] args)
        {
            List<Person> pers_arr = new List<Person>();
            Console.WriteLine("Create new Hero ;)");
            Console.WriteLine("What are you want ?");
            int ex = 1;
            while (ex != 0)
            {
                Console.Write("\n 1 : Exit \n 2 : Compare person \n 3 : Write file  \n 4 : Read file\n 5 : Show all person    \n 6 : Show short info   \n 7 : LINQ example  \n 8 : Create new person  \n 9 : Serialization  \n 10 : Unserialization \n Enter number of option : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ex = 0;
                        break;
                    case 2:
                        ShowCompare(ref pers_arr);
                        break;
                    case 3:
                        WriteFileAsync( pers_arr);
                        break;
                    case 4:
                        ReadFileAsync(pers_arr);
                        break;
                 
                    case 5:
                        ShowInfo(ref pers_arr);
                        break;
                    case 6:
                        
                        ShowShortInfo(ref pers_arr);
                        break;
                    case 7:
                        linq_filter();
                        break;
                    case 8:
                        Creater(ref pers_arr);
                        break;
                    case 9:
                       Thread ser_thread = new Thread(new ParameterizedThreadStart(serialization_ex));
                        ser_thread.Start(pers_arr);
                        break;
                    case 10:
                        unserialization_ex( pers_arr);
                        break;
                    default:
                        Console.WriteLine("Bye");
                        break;
                }

            }
        }
        #region     show
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
        #endregion

        #region Creater
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
            arr.Add(tmp);
        }
        #endregion

        static void ShowCompare(ref List<Person> arr)
        {
            if (arr.Count <= 1)
            {
                Console.WriteLine("Less then 2 arguments");
            }
            else
            {
                int first, second;
                Console.WriteLine("Which member you want to compare ?");
                Console.Write("First : ");
                first = Convert.ToInt32(Console.ReadLine());
                Console.Write("Second : ");
                second = Convert.ToInt32(Console.ReadLine());
                arr[first].CompareTo(arr[second]);
            }
        }
        

        static async Task WriteFileAsync(List<Person> arr)
        {
            await Task.Run(() => WriteFile(ref arr));
        }


        static void WriteFile(ref List<Person> arr)
        {
           
            using (var tmp = new StreamWriter("base_of_people.txt", true))
            {
                foreach (var str in arr)
                {
                    tmp.Write($"Name  {str.name}\nAge  {str.age}\nSex  {str.sex}\nProfession  {str.per_prof.type_work}\nExperience  {str.per_prof.exp}\nSalary  {str.per_prof.salary}\nCard  {str.per_card.type}\nNumber_card  {str.per_card.number}\n");
                }
            }
        }


        static async Task ReadFileAsync(List<Person> arr)
        {
            await Task.Run(() => ReadFile(ref arr));
        }

        static void ReadFile(ref List<Person> arr)
        {
            
            int exp, type_card, salary , num_card;
            string[] line_read;
            string name , sex , profession;
            List<string> file_content = new List<string>();
            string tmp_str;
            if (System.IO.File.Exists("base_of_people.txt"))
            {
                using (var tmp = new StreamReader("base_of_people.txt"))
                {
                    while (!tmp.EndOfStream)
                    {  
                        tmp_str = tmp.ReadLine();
                        line_read = tmp_str.Split(' ');
                        file_content.Add(line_read[2]);
                    }
                    for (int i = 0; i < file_content.Count; i++)
                    {
                        name = file_content[i];
                       int age = Convert.ToInt32(file_content[i + 1]);
                        sex = file_content[i + 2];
                        Person tmp_read_pers = new Person(age, name, sex);
                        profession = file_content[i + 3];
                        exp = Convert.ToInt32(file_content[i +4]);
                        salary = Convert.ToInt32(file_content[i + 5]);
                        tmp_read_pers.per_prof = new Profession(profession, exp, salary);
                        tmp_read_pers.per_card = new Card();
                        type_card = Convert.ToInt32(file_content[i + 6]);
                        num_card = Convert.ToInt32(file_content[i + 7]);
                        i += 7;
                        arr.Add(tmp_read_pers);
                    }

                }
            }
            else { Console.WriteLine("\nFile does not exist !"); }
        }



      static  void  linq_filter()
        {
            Console.Write("\nLINQ array contains : ");
            foreach (string ex in linq_example)
            { 
                Console.Write($"{ex} ");
            }
            var selected = from tmp in linq_example where tmp.StartsWith("1")  select tmp;
            Console.Write("\nSelected start with 1 : ");
            foreach (string ex in selected)
            {
                Console.Write($"{ex} ");
            }
        }
    
        static void serialization_ex(object arr)
        {
            List<Person> tmp = (List<Person>)arr;
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tmp);
                Console.WriteLine("Объект сериализован");
            }
        }
        static void unserialization_ex(List<Person> arr)
        {
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                List<Person> deserilizePeople = (List<Person>)formatter.Deserialize(fs);
                foreach (Person p in deserilizePeople)
                {
                    Console.WriteLine($"Имя: {p.name} --- Возраст: {p.age}");
                }
            }
        }

    }

}
