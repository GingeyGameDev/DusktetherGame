using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    GameObject player;

    public bool playerTurnOver = false;
    bool playerMoving = false;

    float moveHorizontal;
    float moveVertical;

    public int moveSpeed = 1;

    public GameObject currentSpace;

    public GridManager gridManager;
    

    private void Start()
    {
        player = gameObject;
        gridManager = FindObjectOfType<GridManager>();
        Debug.Log(moveSpeed);
    }

    public void playerTurnStart()
    {
        playerTurnOver = false;
        playerMoving = true;

    }

    private void Update()
    {
        if (!playerMoving) 
        {
            playerTurnOver = true;
        }

        if (playerMoving)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");

            if (moveHorizontal >= 0.5f)
            {
                

                currentSpace = FindNextObject(moveSpeed, 0);
                
                MovePlayer();
                playerMoving = false;
            }

           else if (moveHorizontal <= -0.5f)
            {
                

                currentSpace = FindNextObject(-moveSpeed, 0);

                MovePlayer();
                playerMoving = false;
            }

            else if (moveVertical >= 0.5f)
            {
                

                currentSpace = FindNextObject(0, moveSpeed);

                MovePlayer();
                playerMoving = false;
            }
            else if (moveVertical <= -0.5f)
            {
                

                currentSpace = FindNextObject(0, -moveSpeed);

                MovePlayer();
                playerMoving = false;
            }
        }

    }





    void MovePlayer() 
    {
        
            player.transform.position = currentSpace.transform.position;
        
    }

    GameObject FindNextObject(int xMove, int yMove)
    {
        GameObject tempObject = null;
        for (var i = 0; i < gridManager.gridSpaces.Count; i++)
        {


            if (gridManager.gridSpaces[i].name == (int.Parse(currentSpace.name.Substring(0, 1)) + xMove).ToString() + " " + (int.Parse(currentSpace.name.Substring(1, 2)) + yMove).ToString())
            {
                tempObject =  gridManager.gridSpaces[i];
                
            }
            
        }
        if (tempObject == null)
        {
            return currentSpace;
        }
        else 
        {
            return tempObject;
        }
    }
}

