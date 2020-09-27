using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject Menu;
    public Button pause;
    // Start is called before the first frame update
    void Start()
    {
        pause.onClick.AddListener(delegate {showMenu();});
    }

    // Update is called once per frame
    void Update()
    {

    }

    // pulls up in game Menu
    void showMenu()
    {
      Menu.SetActive(true);
    }
}
