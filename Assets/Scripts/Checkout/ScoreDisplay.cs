using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text score;
    public HealthBar healthBar;
    private int currentHealth;

    // Update is called once per frame
    void Update()
    {
        currentHealth = healthBar.getHealth();//get the current value of the health bar
        score = GetComponent<Text>();
        //Tells the user they have completed the level and displays their health score
        score.text = "Level Completed!\n\nHealth Score: "+ currentHealth;
    }
}
