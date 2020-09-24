﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutMenu : MonoBehaviour
{
    //Checks if the user has cheked the checkout
    public static bool gameOver = false;

    public Button btnCheckout;

    //public Button btnExit;

    public GameObject checkoutMenuUI;

    void Start(){
        checkoutMenuUI.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        btnCheckout = GameObject.Find("CheckoutButtonContainer/Button").GetComponent<Button>();
        btnCheckout.onClick.AddListener(Checkout);
        //checkoutMenuUI = GameObject.Find("CheckoutMenuContainer/CheckoutMenu").GetComponent<GameObject>();
        
        //checks if the checkout button has been clicked
        if(gameOver){
        	ExitMenu();
        }
        
    }

    void Checkout()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the checkout button!");
        gameOver = true;
    }
    //displays the users score
    void ExitMenu()
    {
    	checkoutMenuUI.SetActive(true);
    	gameOver = true;
    }
    

    
}