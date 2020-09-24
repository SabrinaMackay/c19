using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_check : MonoBehaviour
{
    // For the pop up when the player loses points
    public GameObject pointsPopup;
    //for sanitiser shield
    public GameObject avatarPlain;
    public SwitchAvatars a;

    public GameObject Avatar_Masked;
    public GameObject Avatar_Bubbled;
    public GameObject enemy_type1;
    public GameObject enemy_type2;
    public GameObject enemy_type3;
    public GameObject enemy_type1_1;
    public GameObject enemy_type2_1;
    public GameObject enemy_type3_1;
    public float dist;
    public float socialDistance = 3;
    //flags to ensure player is only penalised once per instance of violation instead of per frame
    private bool flag1 = true, flag2 = true, flag3 = true, flag4 = true, flag5 = true, flag6 = true;
    public Slider slider; //health bar
    // Start is called before the first frame update
    public void Start()
    {
        a = avatarPlain.GetComponent<SwitchAvatars>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a.whichAvatarIsOn == 4)
        {
            socialDistance = 2;
            dist = Vector2.Distance(Avatar_Bubbled.transform.position, enemy_type1.transform.position);
            if (dist < socialDistance & flag1)//3 is just below the min distance when jumping over an npc
            {
                Debug.Log("social violation");
                //slider.value = slider.value - 5;
                flag1 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE!";
                a.SwitchAvatar();
            }
            else if (dist > socialDistance)//reset penalty check
            {
                flag1 = true;
            }

            dist = Vector2.Distance(Avatar_Bubbled.transform.position, enemy_type2.transform.position);
            if (dist < socialDistance & flag2)
            {
                Debug.Log("social violation");
                //slider.value = slider.value - 5;
                flag2 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE!";
                a.SwitchAvatar();
            }
            else if (dist > socialDistance)
            {
                flag2 = true;
            }

            dist = Vector2.Distance(Avatar_Bubbled.transform.position, enemy_type3.transform.position);
            if (dist < socialDistance & flag3)
            {
                Debug.Log("social violation");
                //slider.value = slider.value - 5;
                flag3 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE!";
                a.SwitchAvatar();
            }
            else if (dist > socialDistance)
            {
                flag3 = true;
            }

            dist = Vector2.Distance(Avatar_Bubbled.transform.position, enemy_type1_1.transform.position);
            if (dist < socialDistance & flag4)
            {
                Debug.Log("social violation");
                //slider.value = slider.value - 5;
                flag4 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE!";
                a.SwitchAvatar();
            }
            else if (dist > socialDistance)
            {
                flag4 = true;
            }

            dist = Vector2.Distance(Avatar_Bubbled.transform.position, enemy_type2_1.transform.position);
            if (dist < socialDistance & flag5)
            {
                Debug.Log("social violation");
                //slider.value = slider.value - 5;
                flag5 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE!";
                a.SwitchAvatar();
            }
            else if (dist > socialDistance)
            {
                flag5 = true;
            }

            dist = Vector2.Distance(Avatar_Bubbled.transform.position, enemy_type3_1.transform.position);
            if (dist < socialDistance & flag6)
            {
                Debug.Log("social violation");
                //slider.value = slider.value - 5;
                flag6 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE!";
                a.SwitchAvatar();
            }
            else if (dist > socialDistance)
            {
                flag6 = true;
            }
        }
        else
        {
            socialDistance = 3;
            dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type1.transform.position);
            if (dist < socialDistance & flag1)//3 is just below the min distance when jumping over an npc
            {
                Debug.Log("social violation");
                slider.value = slider.value - 5;
                flag1 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE! -5";
                
            }
            else if (dist > socialDistance)//reset penalty check
            {
                flag1 = true;
            }

            dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type2.transform.position);
            if (dist < socialDistance & flag2)
            {
                Debug.Log("social violation");
                slider.value = slider.value - 5;
                flag2 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE! -5";
                
            }
            else if (dist > socialDistance)
            {
                flag2 = true;
            }

            dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type3.transform.position);
            if (dist < socialDistance & flag3)
            {
                Debug.Log("social violation");
                slider.value = slider.value - 5;
                flag3 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE! -5";
                
            }
            else if (dist > socialDistance)
            {
                flag3 = true;
            }

            dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type1_1.transform.position);
            if (dist < socialDistance & flag4)
            {
                Debug.Log("social violation");
                slider.value = slider.value - 5;
                flag4 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE! -5";
                
            }
            else if (dist > socialDistance)
            {
                flag4 = true;
            }

            dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type2_1.transform.position);
            if (dist < socialDistance & flag5)
            {
                Debug.Log("social violation");
                slider.value = slider.value - 5;
                flag5 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE! -5";
                
            }
            else if (dist > socialDistance)
            {
                flag5 = true;
            }

            dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type3_1.transform.position);
            if (dist < socialDistance & flag6)
            {
                Debug.Log("social violation");
                slider.value = slider.value - 5;
                flag6 = false;

                // violation pop up
                GameObject points = Instantiate(pointsPopup, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = "TOO CLOSE! -5";
                
            }
            else if (dist > socialDistance)
            {
                flag6 = true;
            }
        }


    }


}
