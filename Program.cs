using ShoppingList;

decimal TotalWeightAllowed = 20.00m;

//Items available for purchase 
List<ShoppingItem> itemsOnSale = new List<ShoppingItem>
{
    new ShoppingItem("Water bottle (1L)",1),
    new ShoppingItem("Jar of olives",0.5m),
    new ShoppingItem("Apple",0.2m),
    new ShoppingItem("Bag of french fries",0.6m),
    new ShoppingItem("6 pack of beer cans",0.9m),
    new ShoppingItem("Cereal box",0.5m),
    new ShoppingItem("100 paper sheets pack",0.8m),
    new ShoppingItem("Red cotton T shirt",0.3m),
    new ShoppingItem("Pack of 6 Paper towels rolls",0.4m),
    new ShoppingItem("Pack of 6 Baking powder",5.0m),
    new ShoppingItem("Box of tissues",0.1m)
};

//List of items we want to buy
List<ShoppingItem> toBuyList = new List<ShoppingItem>();

decimal currentWeight = 0.0m;

//We will keep adding articles as long as we don't exceed the max weigh allowed
while (currentWeight <= TotalWeightAllowed)
{    
    //We add a random artticle of the one's available
    //it allows duplicates
    ShoppingItem item = itemsOnSale[new Random().Next(0, itemsOnSale.Count - 1)];
    if((currentWeight + item.Weight) > TotalWeightAllowed)
    {
        //it will exceed the weight limit, we won't add more items
        // Console.WriteLine($"WEIGHT IS NEAR MAX: {currentWeight + item.Weight}");
        break;        
    }
    else
    {
        ShoppingItem.AddOrdered(item, toBuyList);
        currentWeight += item.Weight;
    }
}
Console.WriteLine("The items we added are:");

foreach (ShoppingItem item in toBuyList) 
{
    Console.WriteLine($"· {item.ToString()}");
}

Console.WriteLine($"The total weight of the cart was {ShoppingItem.CountTotalWeight(toBuyList)} kg");



