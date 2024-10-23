using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Enemy : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] Conversation behaviour;
    [SerializeField] float patrolMinX;
    [SerializeField] float patrolMaxX;
    [SerializeField] float movementSpeed = 2;
    [SerializeField] float detectionDistance = 4;
    [SerializeField] int assignedRoom = 0;
    [SerializeField] bool neutralEnemy = false;
    [SerializeField] GameObject blackExclamation;
    [SerializeField] Animator animator;
    
    //Variables
    bool goingRight = true;
    bool playerCaught = false;
    public bool enemyAware = true;
    bool deceiptHasBeenCalled = false;
    
    

    //Cached Reference
    Player player;
    Level level;
    TextMeshPro text;
    GameObject textObject;
    GameObject exclamation;
    Deceit deceit;
    NeutralConversation nc;
    

    // Start is called before the first frame update
    void Start()
    {
        //Find everything
        player = FindObjectOfType<Player>();
        level = FindObjectOfType<Level>();
        text = GetComponentInChildren<TextMeshPro>();
        textObject = transform.GetChild(0).gameObject;
        deceit = FindObjectOfType<Deceit>();
        nc = FindObjectOfType<NeutralConversation>();

        if (tag == "Sleeping")
        {
            animator.SetBool("isSleeping", true);
            text.text = "ZZZZZ";
            text.enabled = true;
        }
        if (transform.localScale.x <= -1)
        {
            goingRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the tag is "Enemy", which means that they are awake and patrolling
        if (tag == "Enemy")
        {
            //Animation
            animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
            //Patrol if player hasn't been caught yet
            if (!playerCaught)
            {
                Patrol();
            }
            else
            {
                Caught();
            }
            //If the player is in the same room, not hiding, and the enemy is aware, detect the player
        if (level.currentRoom == assignedRoom && !level.isPlayerHidden && enemyAware && !level.deceitOngoing)
            {
                DetectPlayer();
            }
        }

    }

    private void Patrol()
    {
        //Enemy Goes Back and Forth between patrol area
        if (transform.position.x <= patrolMaxX && goingRight)
        {   
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 0);
           
        }
        else if (transform.position.x >= patrolMaxX)
        {
            goingRight = false;

            //Flip
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
            theScale.x = -1;
            textObject.transform.localScale = theScale;
        }

    
        if (!goingRight && transform.position.x >= patrolMinX)
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, 0);
        }
        else if (transform.position.x <= patrolMinX)
        {
            goingRight = true;
            
            //Flip
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
            theScale.x = 1;
            textObject.transform.localScale = theScale;
            
        }
    }   

    private void DetectPlayer()
    {
        float playerPosX = player.transform.position.x;
        float playerPosY = player.transform.position.y;
        float detectAreaMax = transform.position.x + detectionDistance;
        
        if (goingRight) 
        {
            if (playerPosX <= detectAreaMax && playerPosX >= transform.position.x && !playerCaught && playerPosY <= transform.position.y + 1
             && playerPosY >= transform.position.y) 
            {
                exclamation = Instantiate(blackExclamation, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z),Quaternion.identity);
                playerCaught = true;
            }
        }
        else 
        {  
            detectAreaMax = transform.position.x - detectionDistance;
            if (playerPosX >= detectAreaMax && playerPosX <= transform.position.x && !playerCaught && playerPosY <= transform.position.y + 1 
            && playerPosY >= transform.position.y) 
            {
                exclamation = Instantiate(blackExclamation, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z),Quaternion.identity);
                playerCaught = true;
            }
        }
    }

    private void Caught()
    {
        
        exclamation.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        text.enabled = true;

        if (!deceiptHasBeenCalled)
        {
            deceiptHasBeenCalled = true;
            enemyAware = false;
            StartCoroutine(WaitUntilDeceit());
            IEnumerator WaitUntilDeceit()
            {
                if (!neutralEnemy)
                {
                    deceit.InitiateDeceipt(behaviour);
                }
                else
                {
                    nc.InitiateNeutralConversation(behaviour);
                }

                while (!level.deceitDone)
                {
                    if (level.deceitDone == true)
                    {
                        break;
                    }
                    yield return null;
                }
                level.deceitDone = false;
                playerCaught = false;
                Destroy(exclamation);
                text.enabled = false;
            }

        }

    }
}
    
