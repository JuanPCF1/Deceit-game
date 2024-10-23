using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningDoor : MonoBehaviour
{
    //Cached Reference
    SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            sceneLoader.LoadNextScene();
        }
    }


}
