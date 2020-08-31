using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneHome : MonoBehaviour
{
	private float startScene = 0f; 
	private float sceneTimer;
	private float nextFrame = 6f;
	private int counter = 1;

	private Vector3 frameStart = new Vector3(275f,-2.79f,-10f);
	private Vector3 frameOne = new Vector3(290f, -2.79f, -10f);
	private Vector3 frameTwo = new Vector3(320f, -2.79f, -10f);
	private Vector3 frameThree = new Vector3(347f, -2.79f, -10f);

    // Start is called before the first frame update
    void Start()
    {
        sceneTimer = startScene;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x>frameStart.x){
            transform.position = frameStart;
        	if(counter<5)
        {
            sceneTimer += Time.deltaTime;
        }
            if(sceneTimer >= nextFrame)
            {
            	counter++;
            	switch(counter){
            		case 2:
            				transform.position = Vector3.Lerp(frameStart, frameOne, 1f);
            				break;
    				case 3:
    						transform.position = Vector3.Lerp(frameOne, frameTwo, 1f);
            				break;
                    case 4:
                            
                            transform.position = Vector3.Lerp(frameTwo, frameThree, 1f);
                            break;
            		default:
            				print("error");
            				break;
            	}
            	//transform.position = frame;
            	sceneTimer = startScene;
            }
        }
    }
}
