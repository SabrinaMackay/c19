using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour

{    
    
	private float currentTime;
	private float startTime =0;
	private Text theText;
    private string score;
    private Vector3 frame = new Vector3(10f, -2.79f, -10f);
    private Vector3 frame1 = new Vector3(270f,-2.79f,-10f);
// Start is called before the first frame update
    void Start()
    {   
        theText = GetComponent<Text>();
    	currentTime = startTime;
    }

// Update is called once per frame
    void Update()
    {       if((frame.x <= GameObject.Find("Main Camera").transform.position.x) && (frame1.x >= GameObject.Find("Main Camera").transform.position.x)){
        	currentTime += Time.deltaTime;
            decimal timeDisplay = Decimal.Round(Convert.ToDecimal(currentTime),1);
            theText.text = "Time: " + timeDisplay + " sec";
        }
        else if (frame1.x >= GameObject.Find("Main Camera").transform.position.x){
            score = theText.text;
            theText.text = "";
        }
        else{
            theText.text = "";
        }
    }
}
