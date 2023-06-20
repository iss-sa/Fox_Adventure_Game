using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // hold list of items called collectorItems
    public List<Item> characterItems = new List<Item>(); // list of all character Items
    public ItemDatabase itemDatabase; // reference to database to drag and drop from inspector
    public UIInventory inventoryUI; //grab reference to UI Inventory for methods

    //private bool _itemCollision = false; // true if player collided with an item

    private void Start()
    {
        inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
    }
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
        FindObjectOfType<AudioManager>().Play("PickUpItem");
        Debug.Log("Added item: " + itemToAdd.title);
    }

    //check for item in list/inventory
    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    // to return an item name if in inventory
    public string FindItemInInventory(int id)
    {
        Item _toFind = CheckForItem(id);
        if (_toFind != null)
        {
            return _toFind.title;
        }
        else
        {
            return "none";
        }
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

    private void OnTriggerStay(Collider other)
    {
        // Check if the collider belongs to the item being collected -> can only be picked up if key 'E' pressed

        if (other.CompareTag("Rock") && Input.GetKeyDown(KeyCode.E)) // Rock item found -> add to inventory
        {
            GiveItem("Rock");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Branch") && Input.GetKeyDown(KeyCode.E)) // Branch item found -> add to inventory
        {
            GiveItem("Branch");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Food") && Input.GetKeyDown(KeyCode.E)) // Food item found -> add to inventory
        {
            GiveItem("Food");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Leaves") && Input.GetKeyDown(KeyCode.E)) // Leaves item found -> add to inventory
        {
            GiveItem("Leaves");
            Destroy(other.gameObject);
        }
    }
}
