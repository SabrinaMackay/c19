using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public GameObject pointsPopup;
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    // Item has to dissappear when avatar comes into contact with it
    public virtual void OnTriggerEnter2D(Collider2D avatar)
    {
      if(avatar.gameObject.name.Contains("Avatar"))
      {
        // Mask is worth 10 points
        if(transform.name.Contains("Mask"))
        {
          GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
          points.transform.GetChild(0).GetComponent<TextMesh>().text = "+10";
        }

        // sanitizers are worth 5 points
        if(transform.name.Contains("sanitizer"))
        {
          GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
          points.transform.GetChild(0).GetComponent<TextMesh>().text = "+5";
        }

        // Food items are worth 2 points
        if(transform.parent.name.Contains("Essential"))
        {
          GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
          points.transform.GetChild(0).GetComponent<TextMesh>().text = "+2";
        }

        Destroy(gameObject);
      }
    }
}
