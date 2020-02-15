using System;
using System.Collections.Generic;
using System.Text;


namespace Card_ns
{
    [Serializable]
    class Card
    {//1- medic 2 - soc 
       public int type { get; set; }
       public int number { get; set; }
       public Card() { }
    }
}
