using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelVisibility : MonoBehaviour
{
	// The buttons for each level
	public Button level1, level2, level3, level4, level5, level6;

    // Start is called before the first frame update
    void Start()
    {
        level1.onClick.AddListener(delegate {InteractableLevel(1); });
        level2.onClick.AddListener(delegate {InteractableLevel(2); });
        level3.onClick.AddListener(delegate {InteractableLevel(3); });
        level4.onClick.AddListener(delegate {InteractableLevel(4); });
        level5.onClick.AddListener(delegate {InteractableLevel(5); });
        level6.onClick.AddListener(delegate {InteractableLevel(6); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InteractableLevel(int level)
    {
    	//Allows the user to have access to the current level and enables them to go to the next level
    	switch(level)
    	{
    		case 1:
    			level2.interactable = true;
    			//The scenes will be switched
    			//SceneManager.LoadScene (sceneName:"SingleChoice1");
    			break;
    		case 2:
    			level3.interactable = true;
    			// add code to switch scene
    			break;
    		case 3:
    			level4.interactable = true;
    			// add code to switch scene
    			break;
    		case 4:
    			level5.interactable = true;
    			// add code to switch scene
    			break;
    		case 5:
    			level6.interactable = true;
    			// add code to switch scene
    			break;
    		case 6:
    			SceneManager.LoadScene (sceneName:"Quiz");
    			break;
    		
    	}
    }
}
