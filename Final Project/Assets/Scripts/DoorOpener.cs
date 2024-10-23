using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{   
    //Cached reference
    SpriteRenderer door;
    BoxCollider2D doorCollider;

    void Start()
    {
        //Find everything we need
        door = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionStay2D(Collision2D collision) //If player hits door, open it
    { 
        if (collision.gameObject.tag == "Player")
        {  
            if (Input.GetKeyDown(KeyCode.E))
            {
            StartCoroutine(DoorOpen());
            }
        }
    }

    IEnumerator DoorOpen() //Disables collider to enable player to pass through. Makes the door opaque for visuals
    {
        door.color = new Color (0.5f,0.5f,0.5f,0.5f);
        doorCollider.enabled = false;
        

        yield return new WaitForSeconds(1);
        
        
        door.color = new Color (0.5f,0.5f,0.5f,1f);
        doorCollider.enabled = true;
    }
}
