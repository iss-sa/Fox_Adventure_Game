using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
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

    void BuildDatabase()
    {
        items = new List<Item>() {
                new Item(0, "Box", "A magical Box",
                new Dictionary<string, int>
                {
                    {"Power", 15},
                    {"Defense", 10}
                })
            };
    }
}
