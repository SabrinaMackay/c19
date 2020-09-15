using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShoppingLevelToMenu : MonoBehaviour
{
	public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        closeButton = GetComponent<Button>();
      	closeButton.onClick.AddListener(exitLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method will change the scene to the main menu
    void exitLevel()
    {
      // SceneManager.LoadScene (sceneName:"MainMenu");
      Destroy(transform.parent.parent.parent.gameObject);
    }
}
