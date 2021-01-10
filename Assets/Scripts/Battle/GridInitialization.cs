using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInitialization : MonoBehaviour
{
    public int sizeX, sizeY;

    public Vector2 gridNum;
    private Vector3 gridLocation;

    public GameObject gridTile;
    List<GameObject> gridTiles = new List<GameObject>();

    public List<GameObject> enemies = new List<GameObject>();
  

    [SerializeField]
    public Sprite[] gridTileSprites;

    private void Start()
    {
        InitializeGrid();

        
    }
    public void InitializeGrid() 
    {
        gridLocation = new Vector3(-1, 1, 0);

        for (gridNum.x = 1; gridNum.x <= sizeX; gridNum.x++) 
        {
            gridLocation.x += 2;
            gridLocation.y = 1;

              for (gridNum.y = 1; gridNum.y <= sizeY; gridNum.y++) 
              {
                   
                 gridLocation.y -= 2;

                  GameObject tempGameObject;
                  tempGameObject = Instantiate (gridTile, gridLocation, Quaternion.identity);

                  gridTiles.Add(tempGameObject);
                  gridTiles[gridTiles.Count - 1].name = (gridNum.x.ToString() + " " + gridNum.y.ToString());

                //  Debug.Log("grid tile" + gridNum.x + gridNum.y + "Instantiated");

           } 
        }

        //enemy initializing

        if (GameObject.FindGameObjectsWithTag("enemy").Length >= 1)
        {

            for (int enemy = 0; enemy < GameObject.FindGameObjectsWithTag("enemy").Length; enemy++)
            {

                enemies.Add(GameObject.FindGameObjectsWithTag("enemy")[enemy]);

                Debug.Log(enemies[0].name);
                
            }
        }
        else 
        {
            Debug.Log("Error: GridInitializer - no enemy found");
        }

        //enemy centering

        if (enemies.Count >= 1) 
        {
            for (int i = 0; i < enemies.Count; i++) 
            {
                enemies[i].transform.Translate(new Vector3( (((sizeX * 2) / enemies.Count) * (i + 1) -1 ), 0.0f, 0.0f));
            }
        }
    }


    
}
