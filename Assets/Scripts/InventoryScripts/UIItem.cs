using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    private Image _spriteImage;
    private UIItem _selectedItem;

    private void Awake()
    {
        _spriteImage = GetComponent<Image>();
        UpdateItem(null);
        //reference to selected item to handle its behaviour when clicked on
        _selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>(); 
    }

    //Updates item
    public void UpdateItem(Item item)
    {
        this.item = item;
        //if there is item, we want to update it
        if(this.item != null)
        {
            _spriteImage.color = Color.white; //colour will be opque white
            _spriteImage.sprite = this.item.icon; //grab icon from the new item and put it into UI
        }
        //if no item
        else
        {
            _spriteImage.color = Color.clear; //will completely hide icon (alpha == 0)
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Define what behaviour when we click on canvas
        //check if where clicked is an item or not
        if(this.item != null)
        {
            //check if it was a selected item, if yes: make copy and replace the one which we kept on SelectedItem
            if(_selectedItem.item != null)
            {
                Item clone = new Item(_selectedItem.item);
                _selectedItem.UpdateItem(this.item); //grab the item and put it inside SelectedItem
                UpdateItem(clone); //save dragged item inside the inventory
            }
            //if there was no previous selectedItem: grab clicked one and clear its spot
            else
            {
                _selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        }
        //no item in inventory and we have had an item selected
        else if(_selectedItem.item != null)
        {
            //drop it inside inventory again
            UpdateItem(_selectedItem.item);
            _selectedItem.UpdateItem(null);
        }
    }

}
