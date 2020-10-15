using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutMenu : MonoBehaviour
{
    //Checks if the user has cheked the checkout
    public static bool gameOver = false;

    public Button btnCheckout;

    public GameObject checkoutMenuUI;

    void Start(){
        checkoutMenuUI.SetActive(false);
        btnCheckout.onClick.AddListener(Checkout);

    }

    // Update is called once per frame
    void Update()
    {
        //checks if the checkout button has been clicked
        if(gameOver){
        	ExitMenu();
        }

    }

    void Checkout()
    {
        gameOver = true;
    }
    //displays the users score
    void ExitMenu()
    {
    	checkoutMenuUI.SetActive(true);
    	gameOver = false;
    }



}
