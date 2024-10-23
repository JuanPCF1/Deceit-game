using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryCheck : MonoBehaviour
{
    [SerializeField] int roomToEnter = 1;

    //Cache Reference
    Level level;

    void Start() 
    {
        level = FindObjectOfType<Level>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        level.currentRoom = roomToEnter;
    }
}
