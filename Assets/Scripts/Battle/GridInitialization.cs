using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInitialization : MonoBehaviour
{
    public Vector2 gridSize;

    [HideInInspector]
    public Vector2 gridNum;
    private Vector3 gridLocation;

    public GameObject gridTile;

    [HideInInspector]
    public List<GameObject> gridTiles = new List<GameObject>();

    public List<GameObject> enemies = new List<GameObject>();
  

    [SerializeField]
    public Sprite[] gridTileSprites;

    Enemy enemy;

    private void Start()
    {
        

        InitializeGrid();

        
    }
    public void InitializeGrid() 
    {
        gridLocation = new Vector3(-1, -1, 0);

        for (gridNum.x = 1; gridNum.x <= gridSize.x; gridNum.x++) 
        {
            gridLocation.x += 2;
            gridLocation.y = -1;

              for (gridNum.y = 1; gridNum.y <= gridSize.y; gridNum.y++) 
              {

                gridLocation.y += 2;

                GameObject tempGameObject;
                  tempGameObject = Instantiate (gridTile, gridLocation, Quaternion.identity);

                  gridTiles.Add(tempGameObject);
                  gridTiles[gridTiles.Count - 1].name = (gridNum.x.ToString() + " " + gridNum.y.ToString());

                gridTiles[gridTiles.Count - 1].transform.SetParent(GameObject.Find(gridNum.x.ToString() + " " +  "1").transform);


                //  Debug.Log("grid tile" + gridNum.x + gridNum.y + "Instantiated");

                
            }

            GameObject.Find(gridNum.x.ToString() + " " + "1").transform.SetParent(gameObject.transform);
        }

        //enemy initializing

        if (GameObject.FindGameObjectsWithTag("enemy").Length >= 1)
        {

            for (int enemy = 0; enemy < GameObject.FindGameObjectsWithTag("enemy").Length; enemy++)
            {

                enemies.Add(GameObject.FindGameObjectsWithTag("enemy")[enemy]);
                
            }
        }
        else 
        {
            Debug.Log("Error: GridInitializer - no enemy found");
        }

        //enemy centering

        if (enemies.Count > 1)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].transform.Translate(new Vector3((((gridSize.x * 2) / enemies.Count) * (i + 1) - 1), 0.0f, 0.0f));
            }
        }
        else 
        {
            enemies[0].transform.Translate(new Vector3(gridSize.x, gridSize.y * 2, 0.0f));
        }

        FindObjectOfType<Camera>().gameObject.transform.Translate(new Vector3(gridSize.x, gridSize.y + 2, 0.0f));
    }


    
}
