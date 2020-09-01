using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneHome : MonoBehaviour
{
	private float startScene = 0f; 
	private float sceneTimer;
	private float nextFrame = 6f;
	private int counter = 1;

	private Vector3 frameStart = new Vector3(265f,-2.79f,-10f);
	private Vector3 frameHouse = new Vector3(290f, -2.79f, -10f);
	private Vector3 frameBathroom = new Vector3(320f, -2.79f, -10f);
	private Vector3 frameLaundry = new Vector3(347f, -2.79f, -10f);

    // Start is called before the first frame update
    void Start()
    {
        sceneTimer = startScene;
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x >= frameStart.x) && (transform.position.x < frameHouse.x))
            {
                transform.position = frameHouse;
            }
        if(transform.position.x >= frameStart.x)
        {sceneTimer += Time.deltaTime;}
        if(sceneTimer >= nextFrame)
            {
                sceneTimer = startScene;
                if(counter == 1)
                    {transform.position = frameBathroom;}
                if(counter == 2)
                    {transform.position = frameLaundry;}
                counter++;
            }
    }
    
}
