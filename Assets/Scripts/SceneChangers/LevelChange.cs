using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private Animator _transition;
    private float _transitionTime = 1f;

    // --- variables to count how often an item is in the inventory of the player
    private int _food = 0;
    private int _rocks = 0;
    private int _branches = 0;
    private int _leaves = 0;
    // ---

    // if player collides with the LevelChanger Object, it is checked if required Items are in inventory 
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            // from level1 to level2 a rock is needed
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                if (_inventory.FindItemInInventory(3) == "Rock")
                    {
                        LoadNextLevel();
                    }
                    else
                    {
                        Debug.Log("Rock missing");
                    }  
            }
            
            // from level2 to level3 a branch is needed
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {   
                if(_inventory.FindItemInInventory(1) == "Branch")
                    {
                        LoadNextLevel();
                    }
                    else
                    {
                        Debug.Log("Branch missing");
                    }
            } 

            // from level3 to level4 food is needed
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {   
                if(_inventory.FindItemInInventory(4) == "Food")
                    {
                        LoadNextLevel();
                    }
                    else
                    {
                        Debug.Log("Food missing");
                    }
            } 

            // to finish level4: Branch, Leaves, Rock, Food needed for a camping place
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                // go through inventory (public List<Item> characterItems = new List<Item>();) and 
                // if food / rock / branch / leaves found:  add 1 to respective variable
                    // if(_inventory.FindItemInInventory(1) == "Branch") {_branches += 1} 
                    // if(_inventory.FindItemInInventory(2) == "Leaves") {_leaves += 1} 
                    // if(_inventory.FindItemInInventory(3) == "Rock") {_rocks += 1} 
                    // if(_inventory.FindItemInInventory(4) == "Food") {_food += 1} 
                

                if(_food == 2 && _rocks == 5 && _branches == 6 && _leaves == 4)
                {
                    LoadNextLevel();
                }
                else
                {
                    Debug.Log("You are still missing some items to be able to build an awesome camp");
                }
            }
        }
    } 

    // load level and trigger animations for 
    private void LoadNextLevel()
        {
            // load scene
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        _transition.SetTrigger("Start");
        // Wait until animation over
        yield return new WaitForSeconds(_transitionTime);
        // Load next Level
        SceneManager.LoadScene(levelIndex);
    }
}
