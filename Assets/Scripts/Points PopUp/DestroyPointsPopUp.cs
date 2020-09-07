using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointsPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // Destroy the points pop up after 1 second (saves memory)
        
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
