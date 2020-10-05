using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelVisibility : MonoBehaviour
{
		// The buttons for each level
		public Button level1, level2, level3, level4;

    public GameObject avatar;

		// persistent storage stuff below

		// Level script access
		Level levelScript;

    // Start is called before the first frame update
    void Start()
    {
				// load level data first
				levelScript = GameObject.Find("Levels").GetComponent<Level>();
				levelScript.LoadUnlockedLevels();

        level1.onClick.AddListener(delegate {InteractableLevel(1); });
        level2.onClick.AddListener(delegate {InteractableLevel(2); });
        level3.onClick.AddListener(delegate {InteractableLevel(3); });
        level4.onClick.AddListener(delegate {InteractableLevel(4); });

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
    			//The scenes will be switched
    			SceneManager.LoadScene (sceneName:"SingleChoice1");
    			break;

    		case 2:
					// check if level has been unlocked first
					if(levelScript.level2 == true)
					{
						level2.interactable = true;
						// add code to switch scene
						SceneManager.LoadScene (sceneName:"TrueFalse2");
					}

    			break;

    		case 3:
					// check if level has been unlocked first
					if(levelScript.level3 == true)
					{
						level3.interactable = true;
						SceneManager.LoadScene(sceneName:"Jeopardy3");
					}

					break;

    		case 4:
					// check if level has been unlocked first
					if(levelScript.level4 == true)
					{
						level4.interactable = true;
						SceneManager.LoadScene(sceneName:"SampleScene");
					}

          break;
    	}
    }


}
