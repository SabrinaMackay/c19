
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizQandA : MonoBehaviour
{	
    //Possible questions and their answers
    public ArrayList question1 =new ArrayList() {"Question 1","Answer 1","Answer 2", "Answer 3","Answer 4"};
	public ArrayList question2 =new ArrayList() {"Question 2","Answer 1","Answer 2", "Answer 3","Answer 4"};
	public ArrayList question3 =new ArrayList() {"Question 3","Answer 1","Answer 2", "Answer 3","Answer 4"};
	public ArrayList question4 =new ArrayList() {"Question 4","Answer 1","Answer 2", "Answer 3","Answer 4"};
	
    //The ArrayList thats content will be displayed on the UI
    public ArrayList displayQuestion =new ArrayList();
    
    //Answer buttons 
    public Button ans1, ans2, ans3, ans4;

    //counter to check the question number
    private int num =0;
	
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
        //Four Questions will be displayed in then there will be a transition to the next scene
        if(num < 4){
            num++;
        }
        if(num>=4){
            SceneManager.LoadScene (sceneName:"SampleScene");
        }
        
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log($"You have clicked the button {number}!");
    }

}
