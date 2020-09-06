using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialCalculator : GameItem
{

    // Start is called before the first frame update
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void OnTriggerEnter2D(Collider2D avatar)
    {
      // food items should only dissappear when collided with Avatar
      if(avatar.gameObject.name.Contains("Avatar"))
      {
        base.OnTriggerEnter2D(avatar);
        // Debug.Log(transform.parent.name);
      }
    }
}
