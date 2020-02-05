using System;
using System.Collections.Generic;
using System.Text;

namespace Profession_ns
{
    class Profession
    {
        public int exp { get; }
        public string type_work { get; }
        public int salary { get; }
        public Profession(string type , int exp , int salary)
        {
            this.type_work = type;
            this.exp = exp;
            this.salary = salary;

        }

    }
}
