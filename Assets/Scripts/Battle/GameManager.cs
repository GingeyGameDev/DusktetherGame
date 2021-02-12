using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private GridInitialization gridInitialization;
    private GridManager gridManager;

    public GameObject enemyDataTransfer;

    EnemyDataTransfer Data;

    public Enemy enemyScript;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
 
        if (instance == null)

 
            instance = this;


        else if (instance != this)

          
            Destroy(gameObject);

        gridInitialization = FindObjectOfType<GridInitialization>();
        gridManager = gridInitialization.gameObject.GetComponent<GridManager>();
        enemyDataTransfer = GameObject.FindWithTag("DataTransfer");
        Data = enemyDataTransfer.GetComponent<EnemyDataTransfer>();


        StartCoroutine(StartUp());
    }

    private IEnumerator StartUp()
    {
        for (var i = 0; i < Data.enemyData.Length; i++)
        {
            if (Data.enemyData[i].GetType() == typeof(Enemy))
            {
                enemyScript = (Enemy)Data.enemyData[i];
            }
        }


        
        gridInitialization.gridSize = enemyScript.GridSize;

        while (gridManager.gridSpaces.Count == 0)
        {
            yield return null;
        }
        for (var i = 0; i < gridManager.gridSpaces.Count; i++) 
        {
            

            if (gridManager.gridSpaces[i].name == enemyScript.PlayerStartPosition.x + " " + enemyScript.PlayerStartPosition.y) 
            {
                

                player.transform.position = gridManager.gridSpaces[i].transform.position;
            }
        }
      
        



    }



    public IEnumerator Turn() 
    {
        yield break;
    
    }


    // Update is called once per frame
    void Update()
    {



    }
}
