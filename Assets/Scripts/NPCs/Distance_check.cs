using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_check : MonoBehaviour
{
    public GameObject Avatar_Masked;
    public GameObject enemy_type1;
    public GameObject enemy_type2;
    public GameObject enemy_type3;
    public GameObject enemy_type1_1;
    public GameObject enemy_type2_1;
    public GameObject enemy_type3_1;
    public float dist;
    //flags to ensure player is only penalised once per instance of violation instead of per frame
    private bool flag1 = true, flag2 = true, flag3 = true, flag4 = true, flag5 = true, flag6 = true;
    public Slider slider; //health bar
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type1.transform.position);
        if (dist < 3 & flag1)//3 is just below the min distance when jumping over an npc
        {
            Debug.Log("social violation");
            slider.value = slider.value - 5;
            flag1 = false;
        }
        else if (dist > 3)//reset penalty check
        {
            flag1 = true;
        }

        dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type2.transform.position);
        if (dist < 3 & flag2)
        {
            Debug.Log("social violation");
            slider.value = slider.value - 5;
            flag2 = false;
        }
        else if (dist > 3)
        {
            flag2 = true;
        }

        dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type3.transform.position);
        if (dist < 3 & flag3)
        {
            Debug.Log("social violation");
            slider.value = slider.value - 5;
            flag3 = false;
        }
        else if (dist > 3)
        {
            flag3 = true;
        }

        dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type1_1.transform.position);
        if (dist < 3 & flag4)
        {
            Debug.Log("social violation");
            slider.value = slider.value - 5;
            flag4 = false;
        }
        else if (dist > 3)
        {
            flag4 = true;
        }

        dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type2_1.transform.position);
        if (dist < 3 & flag5)
        { 
            Debug.Log("social violation");
            slider.value = slider.value - 5;
            flag5 = false;
        }
        else if(dist > 3)
        {
            flag5 = true;
        }

        dist = Vector2.Distance(Avatar_Masked.transform.position, enemy_type3_1.transform.position);
        if (dist < 3 & flag6)
        {
            Debug.Log("social violation");
            slider.value = slider.value - 5;
            flag6 = false;
        }
        else if(dist>3)
        {
            flag6 = true;
        }

    }
   

    }
