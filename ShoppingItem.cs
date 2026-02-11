
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

        public static void AddOrdered(ShoppingItem product, List<ShoppingItem> list)
        {
            if(list.Count == 0)
            {
                list.Add(product);
                return;
            }

            for(int i = 0; i < list.Count; i++)
            {
                //if the product[i] weight's is lower than the product we add it before it
                if(product.Weight > list[i].Weight)
                {
                    list.Insert(i, product);
                    return;
                }
            }
            //The product is the lightest (at least for now)
            list.Add(product);
        }
        //It tells us the total weight of the List<ShoppingItem>
        public static decimal CountTotalWeight(List<ShoppingItem> items)
        {
            if(items.Count <= 0)
            {
                return 0;
            }

            decimal totalWeight = 0;
            
            foreach (var item in items)
            {
                totalWeight += item.Weight;
            }
            return totalWeight;
        }
    }
}
