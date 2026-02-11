using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class ShoppingItem
    {
        public string Name { get; set; }
        //The weight is expressed on kilograms(kg)        
        public decimal Weight { get; set; }

        public ShoppingItem(string name, decimal weight)
        {
            Name = name;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"An {Name} has a weight of ({Weight} kg)";
        }
    }
}
