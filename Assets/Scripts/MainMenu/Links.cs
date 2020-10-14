using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Links : MonoBehaviour
{
    public GameObject LinksUI;
    public Button linkButton;

    private GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        linkButton.onClick.AddListener(delegate {showPopUp();});
    }

    // show pop up with links
    void showPopUp()
    {
      popUp = Instantiate(LinksUI, transform.position, Quaternion.identity) as GameObject;
      Button closeButton = GameObject.Find("FindOutMore(Clone)/Menu/Canvas/closeButton").GetComponent<Button>();
      closeButton.onClick.AddListener(delegate {close();});
    }

    // close UI
    void close()
    {
      Destroy(popUp);
    }
}
