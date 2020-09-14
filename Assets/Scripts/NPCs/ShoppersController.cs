using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppersController : MonoBehaviour
{
    private Rigidbody2D shopper;
    private float horizontal_movement = 0.5f;
    //private float jump_speed = 8f;
    public float move_speed = 2f;
    private float shopper_scale;
    private Animator enemyAnimation;
    // for detecting if shopper is on the onGround
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundLayer;
    private bool isOnGround;


    // Start is called before the first frame update
    void Start()
    {
        // acquiring the shopper's rigidbody
        shopper = GetComponent<Rigidbody2D> ();

        // avatar scale for flipping on the x axis
        shopper_scale = transform.localScale.x;

        //Acquiring Animator
        enemyAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Checking if shopper is on the ground
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // moving right
        if(horizontal_movement > 0f){
          shopper.velocity = new Vector2(horizontal_movement * move_speed, shopper.velocity.y);
          transform.localScale = new Vector2(shopper_scale, transform.localScale.y);
        }
        // moving left
        if(horizontal_movement < 0f){
          shopper.velocity = new Vector2(horizontal_movement * move_speed, shopper.velocity.y);
          transform.localScale = new Vector2(-shopper_scale, transform.localScale.y);
        }

        enemyAnimation.SetFloat("Speed", Mathf.Abs(shopper.velocity.x));
    }

    // Shoppers will move to the opposite direction when they encounter a wood crate or another shopper
    void OnTriggerEnter2D(Collider2D crate)
    {
      // Debug.Log(crate.gameObject.name);
      if(crate.gameObject.name.Contains("wood") || crate.gameObject.name.Contains("enemy") || crate.gameObject.name.Contains("crate"))
      {
        if(horizontal_movement == 0.5f)
        {
          horizontal_movement = -0.5f;

        }
        else
        {
          horizontal_movement = 0.5f;

        }
      }
    }
}
