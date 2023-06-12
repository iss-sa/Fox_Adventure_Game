using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // hold list of items called collectorItems
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase; // reference to database to drag and drop from inspector
    public UIInventory inventoryUI; //grab reference to UI Inventory for methods

    // to toggle inventory or call it
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }

    // give Player new item
    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd); //using UI Inventory method
        Debug.Log("Added item: " + itemToAdd.title);
    }
    //give player an item   
    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd); //using UI Inventory method
        Debug.Log("Added item: " + itemToAdd.title); 

    }
    //check for item in list/inventory
    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }
    //remove item from inventory
    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove); //using UI Inventory method
            Debug.Log("Item removed: " + itemToRemove.title);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the item being collected
        if (other.CompareTag("Box"))
        {
            GiveItem("Box");
            Destroy(other.gameObject);
        }
    }
}
