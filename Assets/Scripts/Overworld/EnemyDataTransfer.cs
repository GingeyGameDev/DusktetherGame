using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataTransfer : MonoBehaviour
{
    public Object[] enemyData;
    public void dataTransfer(Object[] data) 
    {
        

        enemyData = data;
        DontDestroyOnLoad(gameObject);
    }
}
