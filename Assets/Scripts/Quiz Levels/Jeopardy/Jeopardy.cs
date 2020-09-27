using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jeopardy : MonoBehaviour
{
    //Possible questions and their answers
    public ArrayList question1 = new ArrayList() { "Add answer 1 here. Try and keep the answers short", "Question 1", "Question 2", "Question 3" ,"3"};
  	public ArrayList question2 = new ArrayList() { "Add answer 2 here. Try and keep the answers short", "Question 1", "Question 2", "Question 3" ,"1" };
  	public ArrayList question3 = new ArrayList() { "Add answer 3 here. Try and keep the answers short", "Question 1", "Question 2", "Question 3" ,"2"};
  	public ArrayList question4 = new ArrayList() { "Add answer 4 here. Try and keep the answers short", "Question 1", "Question 2", "Question 3" ,"2"};
    public ArrayList question5 = new ArrayList() { "Add answer 5 here. Try and keep the answers short", "Question 1", "Question 2", "Question 3" ,"1"};

    //The ArrayList thats content will be displayed on the UI
    public ArrayList displayQuestion = new ArrayList();

    //Answer buttons
    public Button ans1, ans2, ans3;
    private int checkNumber;

    //Correct and Incorrect Canvas
    public GameObject correctUI;
    public GameObject incorrectUI;
    private GameObject popUp;

    // default colour for the possible answers
    private Color pink = new Color32(255, 47, 102, 217);

    // Score and InfectionBar scripts
    Score scoreScript;
    InfectionBar infectionB;

    // Infection bar
    public int currentHealth;

    //counter to check the question number
    private int num = 0;

    //score tally
    public int score = 1;


    void Start()
    {
        //Button listener method
        ans1.onClick.AddListener(delegate {ChosenAnswer(1); });
        ans2.onClick.AddListener(delegate {ChosenAnswer(2); });
        ans3.onClick.AddListener(delegate {ChosenAnswer(3); });

        // access score Script
        scoreScript = GameObject.Find("Quiz UI/Scores").GetComponent<Score>();
        infectionB = GameObject.Find("Quiz UI/InfectionBarContainer/HealthBar").GetComponent<InfectionBar>();

    }

    void Update(){
        //changes the possible question based on the 'num' value
        switch(num){
            case 0: displayQuestion = question1;
                    break;
            case 1: displayQuestion = question2;
                    break;
            case 2: displayQuestion = question3;
                    break;
            case 3: displayQuestion = question4;
                    break;
        }
        //Displays the question
        Text questionObj = GameObject.Find("Quiz UI/Question Box/Text").GetComponent<Text>();
        questionObj.text = (string)displayQuestion[0];

        //Displays the possible answers
        Text option1 = GameObject.Find("Quiz UI/Solutions/TopLeft Sol/Text").GetComponent<Text>();
        option1.text = (string)displayQuestion[1];
        Text option2 = GameObject.Find("Quiz UI/Solutions/TopRight Sol/Text").GetComponent<Text>();
        option2.text = (string)displayQuestion[2];
        Text option3 = GameObject.Find("Quiz UI/Solutions/BottomLeft Sol/Text").GetComponent<Text>();
        option3.text = (string)displayQuestion[3];

        // Debug.Log("num value: "+num);
    }

    void ChosenAnswer(int number)
    {
        currentHealth = infectionB.getHealth();//get the current value of the health bar

        checkNumber = number;

        //switch checks if answer was correct and displays the corresponding screen
        if(number == int.Parse((string)displayQuestion[4]))
        {
            // change colour of selected option
            switchGreen();

            // display correct UI
            Invoke("correctPopUp",0.5f);

            // add to score. 1st argument is personal 2nd is community
            // I need to have knowledge of the type of q's asked first so i can
            // decide which q is suitable for either the personal or community score.
            // For now, I'm only adding to both scores for a correct answer.
            scoreScript.setScore(1,1);

            // display quiz
            Invoke("backToQuiz", 2);
        }
        else
        {
            // change colour of selected option
            switchRed();

            // increase infection bar by 20
            currentHealth += 33;
            infectionB.SetHealth(currentHealth);

            // display incorrect pop
            Invoke("incorrectPopUp", 0.5f);

            // display next quiz question
            Invoke("backToQuiz", 2);
        }

    }

    void backToQuiz(){

        switchPink();

        if (num < 4){
            num++;

        }
        // if(num>=4){
        //     SceneManager.LoadScene (sceneName:"SampleScene");
        // }

        //Four Questions will be displayed in then there will be a transition to the next scene

    }

    void switchRed()
    {
      switch(checkNumber)
      {
        case 1:
          ans1.GetComponent<Image>().color = Color.red;
          break;

        case 2:
          ans2.GetComponent<Image>().color = Color.red;
          break;

        case 3:
          ans3.GetComponent<Image>().color = Color.red;
          break;

      }
    }

    void switchGreen()
    {
      switch(checkNumber)
      {
        case 1:
          ans1.GetComponent<Image>().color = Color.green;
          break;

        case 2:
          ans2.GetComponent<Image>().color = Color.green;
          break;

        case 3:
          ans3.GetComponent<Image>().color = Color.green;
          break;

      }
    }

    // switch button colour to blue
    void switchPink()
    {
      switch(checkNumber)
      {
        case 1:
          ans1.GetComponent<Image>().color = pink;
          break;

        case 2:
          ans2.GetComponent<Image>().color = pink;
          break;

        case 3:
          ans3.GetComponent<Image>().color = pink;
          break;

      }
    }

    // show correct UI
    void correctPopUp(){
      popUp = Instantiate(correctUI, transform.position, Quaternion.identity) as GameObject;
    }

    // show incorrect UI
    void incorrectPopUp(){
      popUp = Instantiate(incorrectUI, transform.position, Quaternion.identity) as GameObject;
    }

    // reset all values
    public void resetAll()
    {
      num = 0;
      scoreScript.resetScore();
      infectionB.resetBar();
      score = 1;
    }

}
