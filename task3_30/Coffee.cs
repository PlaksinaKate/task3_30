using System;
using System.Collections.Generic;
using System.Linq;

namespace task3_30
{
    internal class Coffee
    {

        public string condition;
        public int weight;

        public Coffee(string condition, int weight)
        {

            this.condition = condition;
            this.weight = weight;

        }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }

        }
    }
}
