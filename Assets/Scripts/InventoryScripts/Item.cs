using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{ 
    // Item class so each item has following properties:
    public int id;
    public string title;
    public string description;
    public Sprite icon;

    // constructor
    public Item(int id, string title, string description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
    }

    // constructor where we grab an item and copy all of it
    public Item(Item item)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
    }
}
