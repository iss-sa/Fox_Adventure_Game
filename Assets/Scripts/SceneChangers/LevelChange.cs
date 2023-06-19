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
