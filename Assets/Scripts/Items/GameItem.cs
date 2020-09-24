using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public GameObject pointsPopup;
    public HealthBar healthBar;
    public int currentHealth;
    
    //access script to form bubbles
    SwitchAvatars a;
    // Start is called before the first frame update
    public virtual void Start()
    {
        a = GameObject.Find("Avatar-Plain").GetComponent<SwitchAvatars>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
      
    }

    // Item has to dissappear when avatar comes into contact with it
    public virtual void OnTriggerEnter2D(Collider2D avatar)
    {
      currentHealth = healthBar.getHealth();//get the current value of the health bar
      
      if(avatar.gameObject.name.Contains("Avatar"))
      {
        // Mask is worth 10 points
        if(transform.name.Contains("Mask"))
        {
          GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
          points.transform.GetChild(0).GetComponent<TextMesh>().text = "+10";
          //print(currentHealth);
          currentHealth += 10;
          healthBar.SetHealth(currentHealth);
        }

        // sanitizers are worth 5 points
        if(transform.name.Contains("sanitizer"))
        {
          GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
          points.transform.GetChild(0).GetComponent<TextMesh>().text = "+5";
          currentHealth += 5;
          healthBar.SetHealth(currentHealth);
                if (a.whichAvatarIsOn == 3)
                {
                    a.SwitchAvatar();
                }
          
          
        }

        // Food items are worth 2 points
        if(transform.parent.name.Contains("Essential"))
        {
          GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
          points.transform.GetChild(0).GetComponent<TextMesh>().text = "+2";
          currentHealth += 2;
          healthBar.SetHealth(currentHealth);
        }

        Destroy(gameObject);
      }
    }
}
