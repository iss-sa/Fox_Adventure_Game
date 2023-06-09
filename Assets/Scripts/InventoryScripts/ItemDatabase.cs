using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // Database for every Item we add

    // get list from Item class
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    // find item by its id - loop over items list
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    // find item by its name - loop over items list
    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    // all items that can be in our database (e.g. all items player can pick up)
    void BuildDatabase()
    {
        items = new List<Item>() 
            {
                new Item(1, "Branch", "A nice branch to help you climb the mountain"),
                new Item(2, "Leaves", "For a tent and a sleeping place? yes please :)"),
                new Item(3, "Rock", "If you can carry this rock, you are impressively strong!"),
                new Item(4, "Food", "To replenish you after a long hike.")
            };
    }
}
