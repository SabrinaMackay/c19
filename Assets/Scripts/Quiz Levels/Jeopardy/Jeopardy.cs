using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jeopardy : MonoBehaviour
{
    //Possible questions and their answers
    public ArrayList question1 = new ArrayList() { "You should seek emergency medical care.", "What should you do if you develop a serious cough?", "What should you do after going to the mall?", "What should you if you wear an unwashed mask?" ,"1", "pers"};
  	public ArrayList question2 = new ArrayList() { "It protects those around you, from you.", "Why should you wash your mask?", "Why should you sanitize your hands?", "What does wearing a mask do?" ,"3", "com"};
  	public ArrayList question3 = new ArrayList() { "Direct contact.", "How do you get somone's attention?", "What should you avoid when around people?", "What should you do when you see your friend?" ,"2", "both"};
  	public ArrayList question4 = new ArrayList() { "You ought to wear a mask.", "What should you do in order to become a doctor?", "What should you do when you want to look like a superhero?", "What should you do when going out in public?" ,"3", "com"};
    public ArrayList question5 = new ArrayList() { "International travel", "What isn't allowed during lockdown Level 5?", "What to do when you get bored?", "What isn't allowed during lockdown level 1?" ,"1", "pers"};
    public ArrayList question6 = new ArrayList() { "Sanitizing your hands protects the people around you.", "Yes, your hands have to be clean before you can make contact.", "Maybe, but it does shield me from getting the virus.", "No, this reduces the number of microorganisms on your hands, thus reduces the chances of you leaving some on the objects you touch." ,"3","pers"};
  	public ArrayList question7 = new ArrayList() { "Utensils can still be shared.", "Yes, but only if they are properly washed before they're used by the next person.", "Sure, they cannot pass on the virus.", "No, the virus may get passed on this way." ,"1", "both"};
  	public ArrayList question8 = new ArrayList() { "Teenagers' health cannot be affected by covid-19.", "What has been globally agreed upon by doctors?", "What is a common misconception about covid-19? ", "Teenagers tend to get sick less often than adults, therefore..." ,"2", "pers"};
  	public ArrayList question9 = new ArrayList() { "All students are still required to go to school.", "Yes, education is important.", "Not really, only a subset can be allowed at one time.", "Maybe, it is the school's choice." ,"2", "pers"};
    public ArrayList question10 = new ArrayList() { "Pure alcohol can be substituted for sanitizers.", "Yes, sanitizers are just alcohol anyway.", "Maybe, these two are more or less the same.", "No, there are different types of alcohol and not all do the same thing." ,"3", "pers"};
    public ArrayList question11 = new ArrayList() { "Social gatherings.", "What is currently allowed under the lockdown level 5 regulations?", "A definite must do in summer.", "These must be avoided." ,"3", "both"};
  	public ArrayList question12 = new ArrayList() { "Only government officials are excused from adhering to the covid-19 regulations.", "Yes, they are an important group of people.", "Hmm, highly possible, so maybe.", "No, no one is allowed to ignore these rules." ,"3", "pers"};

    //The ArrayList thats content will be displayed on the UI
    public ArrayList displayQuestion = new ArrayList();

    //Answer buttons
    public Button ans1, ans2, ans3;
    private int checkNumber;

    // level failed UI buttons
    private Button restart;
    private Button exit;

    //Correct and Incorrect Canvas
    public GameObject correctUI;
    public GameObject incorrectUI;
    public GameObject levelFailedUI;
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

    private int correctAnswer;

    // storage script
    Level levelScript;


    void Start()
    {
        //Button listener method
        ans1.onClick.AddListener(delegate {ChosenAnswer(1); });
        ans2.onClick.AddListener(delegate {ChosenAnswer(2); });
        ans3.onClick.AddListener(delegate {ChosenAnswer(3); });

        // access score Script
        scoreScript = GameObject.Find("Quiz UI/Scores").GetComponent<Score>();
        infectionB = GameObject.Find("Quiz UI/InfectionBarContainer/HealthBar").GetComponent<InfectionBar>();

        // access storage script
        levelScript = GameObject.Find("Quiz UI").GetComponent<Level>();
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
            case 4: displayQuestion = question5;
                    break;
            case 5: displayQuestion = question6;
                    break;
            case 6: displayQuestion = question7;
                    break;
            case 7: displayQuestion = question8;
                    break;
            case 8: displayQuestion = question9;
                    break;
            case 9: displayQuestion = question10;
                    break;
            case 10: displayQuestion = question11;
                    break;
            case 11: displayQuestion = question12;
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

        correctAnswer = int.Parse((string)displayQuestion[4]);
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
          if(string.Equals(displayQuestion[5], "both"))
          {
            scoreScript.setScore(1,1);
          }
          else if(string.Equals(displayQuestion[5], "pers"))
          {
            scoreScript.setScore(1,0);
          }else
          {
            scoreScript.setScore(0,1);
          }

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

          if(currentHealth < 90)
          {
            // display next quiz question
            Invoke("backToQuiz", 2);

          }else
          {
            Invoke("levelFailedPopUp", 2);
          }
        }

    }

    void backToQuiz(){

        switchPink();

        if (num < 12)
        {
            num++;
        }

        // unlcok platformer level
        if(num>=12)
        {
            levelScript.unlockAndSaveLevel(true, true, true);
            SceneManager.LoadScene (sceneName:"MainMenu");
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
      Text ans = GameObject.Find("IncorrectUI(Clone)/Canvas/AnswerText").GetComponent<Text>();
      ans.text = "Answer: \n" + (string)displayQuestion[correctAnswer];
    }

    // reset all values
    public void resetAll()
    {
      num = 0;
      scoreScript.resetScore();
      infectionB.resetBar();
      score = 1;
    }

    // level failed popUp
    void levelFailedPopUp()
    {
      popUp = Instantiate(levelFailedUI, transform.position, Quaternion.identity) as GameObject;
      restart = GameObject.Find("levelFailedUI(Clone)/Buttons/Restart").GetComponent<Button>();
      exit = GameObject.Find("levelFailedUI(Clone)/Buttons/Exit").GetComponent<Button>();
      restart.onClick.AddListener(delegate {Restart(); });
      exit.onClick.AddListener(delegate {Exit(); });
    }

    // level failed functions

    // Restart method
    void Restart()
    {
      resetAll();
      switchPink();
      // need to destroy UI
      Destroy(popUp);
    }

    // Exit method
    void Exit()
    {
      SceneManager.LoadScene("MainMenu");
    }

}
