using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData", order = 51)]
public class Enemy : ScriptableObject
{

    [SerializeField]
    private string enemyName = "You Shouldn't See This";

    [SerializeField]
    private bool boss = false;

    [SerializeField]
    private Vector2 gridSize = new Vector2 (1,1);

    [SerializeField]
    private Vector2 playerStartPosition = new Vector2 (1,1);

    [SerializeField]
    private List<Object> gridAttacks = new List<Object>();

    [SerializeField]
    private List<Object> bhAttacks = new List<Object>();

    [SerializeField]
    private Object attackOrder;

    [SerializeField]
    private TextAsset dialogueFiles = null;


    public string EnemyName
    {
        get
        {
            return enemyName;
        }
    }

    public bool bossFight 
    {
        get
        {
            return boss; 
        }
    }

    public Vector2 GridSize
    {
        get
        {
            return gridSize;
        }
    }

    public Vector2 PlayerStartPosition
    {
        get
        {
            return playerStartPosition;
        }
    }

    public List<Object> gridAttack
    {
        get
        { 
            return gridAttacks;
        }
    }

    public List<Object> bhAttack
    {
        get
        {
            return bhAttacks;
        }
    }


    public TextAsset DialogueFiles
    {
        get
        {
            return dialogueFiles;
        }
    }
}
