
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizQandA : MonoBehaviour
{	
    //Possible questions and their answers
    public ArrayList question1 =new ArrayList() { "Why are masks important during this epidemic?", "They are the trendiest fashion statement", "They keep your face warm", "They prevent droplets from entering your body through the face", "Masks are required to gain entry to most stores" };
	public ArrayList question2 =new ArrayList() { "What does sanitizing your hands do?", "Makes them smell nice, like ethanol", "Sanitizer kills virus on your skin preventing your touch from spreading it", "It makes people feel cleaner", "Sanitizing does nothing" };
	public ArrayList question3 =new ArrayList() { "What is the appropriate Social Distance to maintain?", "None","Half a meter", "One meter","One and a half meters"};
	public ArrayList question4 =new ArrayList() { "When shopping, what is the least safe payment method?", "Cash","Card (tap to pay)", "Card (swipe with PIN)","Mobile payment option (Zapper/Snapscan)"};
	
    //The ArrayList thats content will be displayed on the UI
    public ArrayList displayQuestion =new ArrayList();
    
    //Answer buttons 
    public Button ans1, ans2, ans3, ans4;

    //counter to check the question number
    private int num =0;

    //score tally
    public int score = 1;
	
    void Start()
    {
        //Button listener method 
        ans1.onClick.AddListener(delegate {TaskWithParameters(1); });
        ans2.onClick.AddListener(delegate {TaskWithParameters(2); });
        ans3.onClick.AddListener(delegate {TaskWithParameters(3); });
        ans4.onClick.AddListener(delegate {TaskWithParameters(4); });
        
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
        Text questionObj = GameObject.Find("QuizContainer/Background/ContentContainer/QuestionsContainer/Text").GetComponent<Text>();
        questionObj.text = (string)displayQuestion[0];

        //Displays the possible answers
        Text option1 = GameObject.Find("QuizContainer/Background/ContentContainer/AnswersContainer/Option1/Button/Text").GetComponent<Text>();
        option1.text = (string)displayQuestion[1];
        Text option2 = GameObject.Find("QuizContainer/Background/ContentContainer/AnswersContainer/Option2/Button/Text").GetComponent<Text>();
        option2.text = (string)displayQuestion[2];
        Text option3 = GameObject.Find("QuizContainer/Background/ContentContainer/AnswersContainer/Option3/Button/Text").GetComponent<Text>();
        option3.text = (string)displayQuestion[3];
        Text option4 = GameObject.Find("QuizContainer/Background/ContentContainer/AnswersContainer/Option4/Button/Text").GetComponent<Text>();
        option4.text = (string)displayQuestion[4];
    
    }

    void TaskWithParameters(int number)
    {
        //switch checks if answer was correct
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
        //Four Questions will be displayed in then there will be a transition to the next scene
        if (num < 4){
            num++;
        }
        if(num>=4){
            SceneManager.LoadScene (sceneName:"SampleScene");
        }
        
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log($"You have clicked the button {number}!");
    }

}
