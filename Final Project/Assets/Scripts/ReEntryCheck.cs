using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReEntryCheck : MonoBehaviour
{
    [SerializeField] int roomToReEnter = 0;
    //Cache Reference
    Level level;

    void Start() 
    {
        level = FindObjectOfType<Level>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        level.currentRoom = roomToReEnter;
    }
}
