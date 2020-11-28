using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    
    public string[] lines;

    public string dialogueLine;

    public void ReadLine(TextAsset dialogueFile, int lineNum = 0) 
    {
        if (dialogueFile != null)
        {
            lines = dialogueFile.text.Split('\n');

            lines[lineNum] = lines[lineNum].Trim(' ', '\n', '\r');

            Debug.Log(lines[lineNum]);
            dialogueLine = lines[lineNum];
        }
    }
    
}
