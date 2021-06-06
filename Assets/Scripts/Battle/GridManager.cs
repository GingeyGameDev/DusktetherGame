using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    GridInitialization gridInitializer;

    public List<GameObject> gridSpaces = new List<GameObject>();


    void Start()
    {
        gridInitializer = gameObject.GetComponent<GridInitialization>();

        gridSpaces = gridInitializer.gridTiles;
    }

    public void gridAttack(List<Object> attacks, int round) 
    {
        if (round <= attacks.Count)
        {
            Debug.Log(attacks[round - 1].name);
        }
        else {  }



    }
}
