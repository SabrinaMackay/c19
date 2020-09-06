using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
      closeButton = GetComponent<Button>();
      closeButton.onClick.AddListener(buttonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void buttonClicked()
    {
      // Debug.Log("Button clicked");
      Destroy(transform.parent.parent.parent.gameObject);
    }


}
