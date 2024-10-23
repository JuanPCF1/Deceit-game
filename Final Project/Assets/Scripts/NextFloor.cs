using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloor : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] GameObject connectingDoor;

    //Cached Reference
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = new Vector3(connectingDoor.transform.position.x,connectingDoor.transform.position.y,1);
            }
        }
    }
}
