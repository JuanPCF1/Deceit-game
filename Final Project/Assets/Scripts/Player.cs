using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    
    //Serialized Fields
    [SerializeField] float jumpHeight = 6f;
    [SerializeField] float movementSpeed = 4f;
    [SerializeField] Sprite[] movementSprites;
    [SerializeField] Animator animator;

    //Variables
    public bool movementIsActive = true;

    // Update is called once per frame
    void Update()
    {
        //Keep track of current velocity
        float velocityX = GetComponent<Rigidbody2D>().velocity.x;
        float velocityY = GetComponent<Rigidbody2D>().velocity.y;
        //Animation
        animator.SetFloat("Speed", Mathf.Abs(velocityX));
        animator.SetFloat("Vertical Speed", velocityY);
        //Make sure player stays awake every frame
        GetComponent<Rigidbody2D>().WakeUp();

        if (movementIsActive)
        {
        PlayerMove(ref velocityX, ref velocityY);
        }
        
        if (velocityX >= 0.1 && velocityX <= 4)
        {
            FlipRight();
        }
        else if (velocityX <= -0.1 && velocityX >= -4)
        {
            FlipLeft();
        }
    }

    private void PlayerMove(ref float velocityX, ref float velocityY)
    {
        //RIGHT "D"
        if (Input.GetKey(KeyCode.D))
        {
            velocityX = movementSpeed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
        }
        //LEFT "A"
        if (Input.GetKey(KeyCode.A))
        {
            velocityX = -movementSpeed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
        }
        //JUMP "W"
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (velocityY <= 0.5 && velocityY >= -0.5)
            {
                velocityY = jumpHeight;
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
            }
        }
    }

    void FlipLeft()
    {
        //Flip
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
    }

    void FlipRight()
    {
        //Flip
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
    }

}
