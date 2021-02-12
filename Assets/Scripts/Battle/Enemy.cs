using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects", order = 51)]
public class Enemy : ScriptableObject
{

    [SerializeField]
    private string enemyName;

    [SerializeField]
    private Vector2 gridSize;

    [SerializeField]
    private Vector2 playerStartPosition;

    [SerializeField]
    private List<Object> attacks = new List<Object>();

    [SerializeField]
    private Object attackOrder;

    [SerializeField]
    private TextAsset dialogueFiles;


    public string EnemyName
    {
        get
        {
            return enemyName;
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

    public List<Object> Attacks
    {
        get
        { 
            return attacks;
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
