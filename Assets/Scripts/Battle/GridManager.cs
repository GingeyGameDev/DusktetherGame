using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    GridInitialization gridInitializer;

    public List<GameObject> gridSpaces = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        gridInitializer = gameObject.GetComponent<GridInitialization>();

        gridSpaces = gridInitializer.gridTiles;
    }

    public void gridAttack(int round) 
    { 
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
