using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{

    public string[] lines;

    public string dialogueLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReadLine(TextAsset dialogueFile, int lineNum = 0) 
    {
        lines = dialogueFile.text.Split('\n');

        
            Debug.Log(lines[lineNum]);
            dialogueLine = lines[lineNum];
     
    }

}
