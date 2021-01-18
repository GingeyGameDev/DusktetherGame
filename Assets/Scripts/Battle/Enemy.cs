using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{


    public string enemyName;

    public Vector2 gridSize;

    public Vector2 playerStartPosition;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Battle") 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
