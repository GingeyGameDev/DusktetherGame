using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private GridInitialization gridInitialization;
    private GridManager gridManager;

    private PlayerManager playerManager;

    public GameObject enemyDataTransfer;

    EnemyDataTransfer Data;

    public Enemy enemyScript;

    public GameObject player;

    public string enemyName;

    public int turnValue = 1;

    public float attackTime;

    public int attackPhase;

    public bool gridActivated;

    public int roundNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        //singleton identifier
        if (instance == null)
        {


            instance = this;


        }
            else if (instance != this) 
            { 


            Destroy(gameObject);
             }

        //get player scripts
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();

        //get grid scripts
        gridInitialization = FindObjectOfType<GridInitialization>();
        gridManager = gridInitialization.gameObject.GetComponent<GridManager>();

        //get enemy and attack scripts
        if (GameObject.FindWithTag("DataTransfer"))
        {
            enemyDataTransfer = GameObject.FindWithTag("DataTransfer");
        }

        Data = enemyDataTransfer.GetComponent<EnemyDataTransfer>();
        for (var i = 0; i < Data.enemyData.Length; i++)
        {
            if (Data.enemyData[i].GetType() == typeof(Enemy))
            {
                enemyScript = (Enemy)Data.enemyData[i];
            }
        }


        //initialization
        gridInitialization.gridSize = enemyScript.GridSize;

        Invoke("Initialization", 0.01f);
    }



    //set up all needed things before the first turn
    private void Initialization()
    {
  
        for (var i = 0; i < gridManager.gridSpaces.Count; i++) 
        {
            

            if (gridManager.gridSpaces[i].name == enemyScript.PlayerStartPosition.x + " " + enemyScript.PlayerStartPosition.y) 
            {
                

                player.transform.position = gridManager.gridSpaces[i].transform.position;
            }
        }

        roundNum = 1;
        attackPhase = 1;

        Turn();

    }


    //Branches to each turn state
    //turnValue 1) Player, 2) Status Effect, 3) Enemy, 4) Status Effect
    //attackPhase 1) Grid, 2) Bullet Hell
    public void Turn() 
    {
        
        if (turnValue == 1)
        {
            Debug.Log("Player's Turn");
            StartCoroutine(PlayerTurn());
        }
            else if (turnValue == 2)
            {
                Debug.Log("Status Effect - ");
                turnValue++;
                Turn();
            }
                else if (turnValue == 3)
                {
                    Debug.Log("Enemy's Turn");

                    if (attackPhase == 1) //grid
                    {
                        Debug.Log("Grid Attack");

                        StartCoroutine(EnemyTurnGrid());
                    }
                        else if (attackPhase == 2 && gridActivated == false ) //bullet hell
                        {
                            Debug.Log("Bullet Hell Attack");

                            StartCoroutine(EnemyTurnBH());
                        }
                            else { Debug.Log("Error: GameManager \n | attackPhase is out of range"); }

            
                }
                    else if (turnValue == 4)
                    {
                        Debug.Log("Status Effect - ");
                        turnValue = 1;
                        roundNum++;
                        Debug.Log("Round Ended");
                        Turn();

            
                    }
                    else { Debug.Log("Error: GameManager \n | turnValue is out of range"); }

        
    
    }




    //Player's Turn
    //
    public IEnumerator PlayerTurn() 
    {
        playerManager.playerTurnStart();

        while (!playerManager.playerTurnOver) 
        {
            yield return null;
        }

        turnValue++;
        Turn();
        yield break;
    }



    //enemy's Turn
    //grid phase
    public IEnumerator EnemyTurnGrid() 
    {
        attackPhase++;
        Turn();
        yield break;
    }

    //bullet hell phase
    public IEnumerator EnemyTurnBH() 
    {
        attackPhase = 1;
        turnValue++;
        yield return new WaitForSeconds(5);
        Turn();
        yield break;
    }
}
