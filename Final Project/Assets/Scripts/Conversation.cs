using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Behaviour")]
public class Conversation : ScriptableObject
{
    

    [SerializeField] string[] enemyLines = new string[3];
    [SerializeField] string[] caughtResponses;
    [SerializeField] string[] firstPlayerChoices = new string[4];
    [SerializeField] string[] secondPlayerChoices = new string[4];
    [SerializeField] int[] correctChoices = new int[2];

    public string getFirstEnemyLine()
    {
        return enemyLines[0];
    }

    public string getSecondEnemyLine()
    {
        return enemyLines[1];
    }

    public string getThirdEnemyLine()
    {
        return enemyLines[2];
    }

    public string[] getFirstPlayerChoices()
    {
        return firstPlayerChoices;
    }

    public string[] getSecondPlayerChoices()
    {
        return secondPlayerChoices;
    }

    public int[] getCorrectChoices()
    {
        return correctChoices;
    }

    public string[] getCaughtResponses()
    {
        return caughtResponses;
    }



}
