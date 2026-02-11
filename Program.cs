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
    // Console.WriteLine($"CURRENT WEIGHT IS : {currentWeight}");
    //We add a random artticle of the one's available
    ShoppingItem item = itemsOnSale[new Random().Next(0, itemsOnSale.Count - 1)];
    if((currentWeight + item.Weight) > TotalWeightAllowed)
    {
        //it will exceed the weight limit, we won't add more items
        // Console.WriteLine($"WEIGHT IS NEAR MAX: {currentWeight + item.Weight}");
        break;        
    }
    else
    {
        //Console.WriteLine(item.Name);
        //toBuyList.Add(item);
        AddOrdered(item, toBuyList);
        currentWeight += item.Weight;
    }
}
Console.WriteLine("The items we added are:");

foreach (ShoppingItem item in toBuyList) 
{
    Console.WriteLine($"· {item.ToString()}");
}

Console.WriteLine($"The total weight of the cart was {CountTotalWeight(toBuyList)} kg");
//We know what we are going to buy, we go adding each item on the cart
//We must begin with the heaviest one first

// List<ShoppingItem> cart = toBuyList.OrderByDescending(item => item.Weight).ToList();
// //We list the contents.
// foreach (ShoppingItem item in cart) 
// {
//     Console.WriteLine(item.ToString());
// }
//Console.WriteLine($"The total weight of the cart was {CountTotalWeight(cart)} kg");

void AddOrdered(ShoppingItem product, List<ShoppingItem> list)
{
    if(list.Count == 0)
    {
        list.Add(product);
        return;
    }
    //decimal heaviestWeight = list.Max(x => x.Weight);

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

    // //int heaviestIndex = list.FindIndex(i => i.Weight == list.Max(x => x.Weight));
    // int lightestIndex = list.FindIndex(i => i.Weight < list.Min(x => x.Weight));
    
    // if(lightestIndex == -1)
    // {
    //     //The list was empty, we add the product
    //     list.Add(product);
    // }
    // else
    // {
    //     try
    //     {
    //         list.Insert(lightestIndex, product);            
    //     }
    //     catch(Exception ex)
    //     {
    //         Console.Error.WriteLine($"Error adding the item to the list at index {lightestIndex}: {ex.Message}");
    //     }
    // }
}

//It tells us the total weight of the List<ShoppingItem>
decimal CountTotalWeight(List<ShoppingItem> items)
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