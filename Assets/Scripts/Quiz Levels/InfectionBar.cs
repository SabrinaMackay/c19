using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionBar : MonoBehaviour
{
	public Slider slider; //slider object
	public int maxHealth = 100;


	void Start(){

	SetMaxHealth(maxHealth);
	}


	public void SetMaxHealth(int health){
		slider.maxValue = health;//sets the max slider value
		slider.value = 0;//ensures that the slider's vlaue starts at 0

	}

	public void SetHealth(float health)
	{
		if(health<=0){
			slider.value = 0;
		}
		else{slider.value = health;} //Slider's value will change to the passed parameter

	}

	public int getHealth(){
		int result = (int)slider.value;
		return result;
	}

}
