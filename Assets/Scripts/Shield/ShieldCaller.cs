using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.activeInHierarchy)
        {
          gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // display shield
    public void makeActive()
    {
      gameObject.SetActive(true);
    }

    // make shield inactive
    public void makeInactive(){
      StartCoroutine(dissappear());
    }

    // make shield dissappear after 10 seconds
    IEnumerator dissappear()
    {
      yield return new WaitForSeconds(10f);
      gameObject.SetActive(false);
    }
}
