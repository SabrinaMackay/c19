using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAvatars : MonoBehaviour
{
    // The two avatars
    public GameObject avatar, avatarMasked, avatarBubbled;

    // variable which holds active avatar
    public int whichAvatarIsOn = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Choose plain avatar
        avatar.gameObject.SetActive(true);
        avatarMasked.gameObject.SetActive(false);
        avatarBubbled.gameObject.SetActive(false);
    }

    public void SwitchAvatar()
    {
        switch(whichAvatarIsOn)
        {
          case 1:
            whichAvatarIsOn = 3;

            // disable plain and enable masked avatar
            avatar.gameObject.SetActive(false);
            avatarBubbled.gameObject.SetActive(false);
            avatarMasked.transform.position = new Vector3(avatar.transform.position.x, avatar.transform.position.y, avatar.transform.position.z);
            avatarMasked.SetActive(true);
            break;

          case 2:
            whichAvatarIsOn = 1;

            // disable masked and enable plain
            avatarMasked.gameObject.SetActive(false);
            avatarBubbled.gameObject.SetActive(false);
            avatar.gameObject.SetActive(true);
            break;
          case 3:
                whichAvatarIsOn = 4;
                //disable masked and enable bubbled masked
                avatarMasked.gameObject.SetActive(false);
                //avatar.gameObject.SetActive(false);
                avatarBubbled.transform.position = new Vector3(avatarMasked.transform.position.x, avatarMasked.transform.position.y, avatarMasked.transform.position.z);
                avatarBubbled.gameObject.SetActive(true);
                break;
          case 4:
                whichAvatarIsOn = 3;
                //avatar.gameObject.SetActive(false);
                avatarBubbled.gameObject.SetActive(false);
                avatarMasked.transform.position = new Vector3(avatarBubbled.transform.position.x, avatarBubbled.transform.position.y, avatarBubbled.transform.position.z);
                avatarMasked.SetActive(true);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
