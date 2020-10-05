using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleChoice : MonoBehaviour
{
    //Possible questions and their answers
    public ArrayList question1 = new ArrayList() { "Add question 1 here, Correct answer is 3. What is your question? Is it community or personal score based?", "Option 1", "Option 2", "Option 3", "Option 4" ,"1"};
  	public ArrayList question2 = new ArrayList() { "Add question 2 here, Correct answer is 2. What is your question? Is it community or personal score based?", "Option 1", "Option 2", "Option 3", "Option 4", "2" };
  	public ArrayList question3 = new ArrayList() { "Add question 3 here, Correct answer is 4. What is your question? Is it community or personal score based?", "Option 1", "Option 2", "Option 3", "Option 4","4"};
  	public ArrayList question4 = new ArrayList() { "Add question 4 here, Correct answer is 3. What is your question? Is it community or personal score based?", "Option 1", "Option 2", "Option 3", "Option 4","3"};
    public ArrayList question5 = new ArrayList() { "Add question 5 here, Correct answer is 1. What is your question? Is it community or personal score based?", "BootyEater69", "Option 2", "Option 3", "Option 4", "1"};

    //The ArrayList thats content will be displayed on the UI
    public ArrayList displayQuestion = new ArrayList();

    //Answer buttons
    public Button ans1, ans2, ans3, ans4;
    private int checkNumber;

    //Correct and Incorrect Canvas
    public GameObject correctUI;
    public GameObject incorrectUI;
    private GameObject popUp;

    // default colour for the possible answers
    private Color blue = new Color32(28, 126, 221, 204);

    // Score and InfectionBar scripts
    Score scoreScript;
    InfectionBar infectionB;

    // Infection bar
    public int currentHealth;

    //counter to check the question number
    private int num = 0;

    //score tally
    public int score = 1;

    private int correctAnswer;

    // storage script
    Level levelScript;


    void Start()
    {
        //Button listener method
        ans1.onClick.AddListener(delegate {ChosenAnswer(1); });
        ans2.onClick.AddListener(delegate {ChosenAnswer(2); });
        ans3.onClick.AddListener(delegate {ChosenAnswer(3); });
        ans4.onClick.AddListener(delegate {ChosenAnswer(4); });

        // access score Script
        scoreScript = GameObject.Find("Quiz UI/Scores").GetComponent<Score>();
        infectionB = GameObject.Find("Quiz UI/InfectionBarContainer/HealthBar").GetComponent<InfectionBar>();

        // storage script
        levelScript = GameObject.Find("Quiz UI").GetComponent<Level>();

    }

    void Update(){
        //changes the possible question based on the 'num' value
        switch(num)
        {
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
        Text option4 = GameObject.Find("Quiz UI/Solutions/BottomRight Sol/Text").GetComponent<Text>();
        option4.text = (string)displayQuestion[4];

        //index of the correct answer
        correctAnswer = int.Parse((string)displayQuestion[5]);
        // Debug.Log("num value: "+num);
    }

    void ChosenAnswer(int number)
    {
        currentHealth = infectionB.getHealth();//get the current value of the health bar
        checkNumber = number;
        //switch checks if answer was correct and displays the corresponding screen
        if(number == correctAnswer)
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

        switch (num)
        {
            case 0:
                if (number == 3)
                {
                    score += 1;
                }
                break;
            case 1:
                if (number == 2)
                {
                    score += 1;
                }
                break;
            case 2:
                if (number == 4)
                {
                    score += 1;
                }
                break;
            case 3:
                if (number == 4)
                {
                    score += 1;
                }
                break;
        }

        //Output this to console when Button1 or Button3 is clicked
        Debug.Log($"You have clicked the button {number}!");
    }

    void backToQuiz(){

        switchBlue();

        if (num < 4)
        {
            num++;
        }

        // End of level. Unlock 2nd level
        if(num>=4)
        {
            levelScript.unlockAndSaveLevel(true, false, false);
            SceneManager.LoadScene (PlayerPrefs.GetInt("SavedScene"));
        }

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

        case 4:
          ans4.GetComponent<Image>().color = Color.red;
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

        case 4:
          ans4.GetComponent<Image>().color = Color.green;
          break;
      }
    }

    // switch button colour to blue
    void switchBlue()
    {
      switch(checkNumber)
      {
        case 1:
          ans1.GetComponent<Image>().color = blue;
          break;

        case 2:
          ans2.GetComponent<Image>().color = blue;
          break;

        case 3:
          ans3.GetComponent<Image>().color = blue;
          break;

        case 4:
          ans4.GetComponent<Image>().color = blue;
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
      Text ans = GameObject.Find("IncorrectUI(Clone)/Canvas/AnswerText").GetComponent<Text>();
      ans.text = "Answer: \n" + (string)displayQuestion[correctAnswer];
      //Destroy(gameObject, 2f);
    }

    // reset all values
    public void resetAll()
    {
      num = 0;
      scoreScript.resetScore();
      infectionB.resetBar();
    }

}
