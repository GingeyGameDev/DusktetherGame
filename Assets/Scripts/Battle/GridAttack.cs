using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/GridAttack", order = 49)]
public class GridAttack : ScriptableObject
{
    [SerializeField]
    List<string> gridSpaces= new List<string>();

    [SerializeField]
    List<float> attackTime = new List<float>();


    public List<string> attackedSpaces
    {
        get 
        {
            return gridSpaces;
        }
    }

    public List<float> attackWaitTime 
    {
        get 
        {
            return attackTime;
        }
    }

}
