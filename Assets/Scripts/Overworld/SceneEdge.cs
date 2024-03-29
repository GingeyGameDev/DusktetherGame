﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEdge : MonoBehaviour
{
    //[SerializeField]
    public string nextScene;

    [SerializeField]
    private string scenePosition = "";
    public float sceneMoveAmount;

    private GameObject mainCam;
    private GameObject player;

    CameraController cameraControl;

    [SerializeField]
    private Vector2 camMoveMin = new Vector2(0,0), camMoveMax = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        cameraControl = FindObjectOfType<CameraController>();

        mainCam = cameraControl.gameObject;
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            StartCoroutine("SceneTransition");
        }
    }

    private IEnumerator SceneTransition() 
    {
        string previousScene = SceneManager.GetActiveScene().name;


        AsyncOperation loadNewScene = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        while (!loadNewScene.isDone) 
        {
            yield return null;
        }

        if (scenePosition == "left")
        {
            player.transform.Translate(new Vector3(-sceneMoveAmount, 0.0f, 0.0f));

        } else if (scenePosition == "right")
           {
            player.transform.Translate(new Vector3(sceneMoveAmount, 0.0f, 0.0f));

           } else if (scenePosition == "up")
                {
                  player.transform.Translate(new Vector3(0.0f, sceneMoveAmount, 0.0f));

                } else if (scenePosition == "down")
                    {
                       player.transform.Translate(new Vector3(0.0f, -sceneMoveAmount, 0.0f));

                    } else 
                        {
            Debug.Log("Setup Error: SceneEdge \n | missing scenePosition");

                        }
        


        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(nextScene));
        SceneManager.MoveGameObjectToScene(mainCam, SceneManager.GetSceneByName(nextScene));

        cameraControl.camMoveMin = camMoveMin;
        cameraControl.camMoveMax = camMoveMax;

        cameraControl.mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -15);



        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(previousScene));
        


    }


}
