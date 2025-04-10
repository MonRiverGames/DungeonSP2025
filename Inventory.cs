public class Inventory
{
    public List<Item> Items { get; private set; }

    public Inventory()
    {
        Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            Console.WriteLine($"You have grabbed {item.Name}. {item.Description}");

            // If it's a trap, trigger it immediately
            if (item is Trap trap)
            {
                trap.Trigger();
            }
        }
        else
        {
            Console.WriteLine("You already have this item!");
        }
    }

    public void ShowInventory()
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
            return;
        }

        Console.WriteLine("Your inventory contains:");
        foreach (var item in Items)
        {
            Console.WriteLine($"- {item.Name}: {item.Description}");
        }
    }
}