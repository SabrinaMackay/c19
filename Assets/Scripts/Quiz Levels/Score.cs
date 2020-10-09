using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Scores
    private int personal = 0;
    private int community = 0;

    public Text personalUI;
    public Text communityUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      personalUI.text = "Personal Score: "+personal+"/10";
      communityUI.text = "Community Score: "+community+"/5";
    }

    // Set Score
    public void setScore(int personalIncrease = 0, int communityIncrease = 0)
    {
      personal += personalIncrease;
      community += communityIncrease;
    }

    // Get personal Score
    public int getPersonalScore(){return personal;}

    // Get community Score
    public int getCommunityScore(){return community;}

    // reset score
    public void resetScore()
    {
      personal = 0;
      community = 0;
    }
}
