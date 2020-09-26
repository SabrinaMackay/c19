using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : GameItem
{
    // for accessing script that switches between avatars
    SwitchAvatars currentAvatar;

    // Start is called before the first frame update
    public override void Start()
    {
      currentAvatar = GameObject.Find("Avatar-Plain").GetComponent<SwitchAvatars>();
    }

    // Update is called once per frame
    public override void Update()
    {
    }

    // Switch to mask-wearing avatar
    public override void OnTriggerEnter2D(Collider2D avatar)
    {
      // Destroy(gameObject);
      base.OnTriggerEnter2D(avatar);
      currentAvatar.SwitchAvatar();
    }
}
