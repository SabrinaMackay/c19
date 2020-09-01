using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour
{
    private float startScene = 0f; 
    private float sceneTimer;
    private float nextFrame = 6f;
    private int counter = 1;

    private Vector3 FrameOne =new Vector3(-91f, -2.79f, -10f);
    private Vector3 FrameTwo =new Vector3(-65f, -2.79f, -10f);
    private Vector3 FrameThree =new Vector3(-38f, -2.79f, -10f);
    private Vector3 FrameFour =new Vector3(-22f, -2.79f, -10f);

    
    // Start is called before the first frame update
    void Start()
    {
        sceneTimer = startScene;
        transform.position = FrameOne;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter<5)
        {
            sceneTimer += Time.deltaTime;
        }
            if(sceneTimer >= nextFrame)
            {
                counter++;
                switch(counter){
                    case 2:
                            transform.position = Vector3.Lerp(FrameOne, FrameTwo, 1f);
                            break;
                    case 3:
                            transform.position = Vector3.Lerp(FrameTwo, FrameThree, 1f);
                            break;
                    case 4:
                            
                            transform.position = Vector3.Lerp(FrameThree, FrameFour, 1f);
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
