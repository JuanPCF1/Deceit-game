using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    //Cached References
    Level level;
    Player player;

    private void Start()
    {
        //Find all required objects
        level = FindObjectOfType<Level>();
        player = FindObjectOfType<Player>();
        //Set the Z to display behind player
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 0.5f);
    }

    //If the plyer is touching the item
    private void OnTriggerStay2D(Collider2D collision) 
    {
        //Make sure the collison is from a player and not an enemy
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.S))
            {
                Hide();
            }
            else //Else, set the object back to behind player, player is not hiding
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 0.5f);
                level.isPlayerHidden = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //If the player exits the object, do not hide anymore
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 0.5f);
            level.isPlayerHidden = false;
        }
    }

    public void Hide() //Sets Z to be on top of Player, and track that he is hiding
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 0.5f);
        level.isPlayerHidden = true;
    }

    
}
