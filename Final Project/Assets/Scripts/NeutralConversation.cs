using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NeutralConversation : MonoBehaviour
{
//Serialized Fields
    [SerializeField] TextMeshProUGUI enemySpeech;
    [SerializeField] TextMeshProUGUI choice1;
    [SerializeField] TextMeshProUGUI choice2;
    [SerializeField] TextMeshProUGUI choice3;
    [SerializeField] TextMeshProUGUI choice4;
    [SerializeField] TextMeshProUGUI detectionState;

    //Variables
    int chosenChoice;
    

    //Cached reference
    Player player;
    Level level;
    SceneLoader sceneLoader;
    

    void Start()
    {
        //Get all the needed objects
        player = FindObjectOfType<Player>();
        level = FindObjectOfType<Level>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        //Set the current level to the current level
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
    }


    public void InitiateNeutralConversation(Conversation behaviour)
    {
        level.deceitOngoing = true;
        player.movementIsActive = false;
        StartCoroutine(DeceitRoutine());
        IEnumerator DeceitRoutine()
        {
        //First, the enemy initiates the conversation
        detectionState.text = "Detected";
        enemySpeech.text = behaviour.getFirstEnemyLine();

        //Second, the player choices are displayed
        choice1.text = "1. " + behaviour.getFirstPlayerChoices()[0];
        choice2.text = "2. " + behaviour.getFirstPlayerChoices()[1];
        choice3.text = "3. " + behaviour.getFirstPlayerChoices()[2];
        choice4.text = "4. " + behaviour.getFirstPlayerChoices()[3];

        //Third, the play CHOOSES one of these options
        yield return StartCoroutine(WaitUntilChoice());
        
        //Choice doesn't matter
        enemySpeech.text = behaviour.getSecondEnemyLine();
        
        //Fifth, display second set of choices for the player
        choice1.text = "1. " + behaviour.getSecondPlayerChoices()[0];
        choice2.text = "2. " + behaviour.getSecondPlayerChoices()[1];
        choice3.text = "3. " + behaviour.getSecondPlayerChoices()[2];
        choice4.text = "4. " + behaviour.getSecondPlayerChoices()[3];

        //Sixth, the player makes his selection
        yield return StartCoroutine(WaitUntilChoice());

        //Choice doesn't matter
            detectionState.text = "Decieved!";
            enemySpeech.text = behaviour.getThirdEnemyLine();
            player.movementIsActive = true;
            level.deceitDone = true;
            level.deceitOngoing = false;
            choice1.text = "";
            choice2.text = "";
            choice3.text = "";
            choice4.text = "";
            yield return new WaitForSeconds(4);
            enemySpeech.text = "";
            detectionState.text = "Undetected";
        }
        //Now, the enemy goes back to what he was doing, but will not detect the player again
    }

    private IEnumerator WaitUntilChoice()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                chosenChoice = 1;
                done = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                chosenChoice = 2;
                done = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                chosenChoice = 3;
                done = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                chosenChoice = 4;
                done = true;
            }

            yield return null;
        }
    }
}

