using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    
    public string[] lines;

    public string dialogueLine;

    public void ReadLine(TextAsset dialogueFile, string name, int timesInteracted = 0, int lineNum = 0) 
    {
        if (dialogueFile != null)
        {
            int dialoguestartline = dialogueFile.text.IndexOf('<' + name + '-' + timesInteracted + '>');
            Debug.Log('<' + name + '-' + timesInteracted + '>');
            Debug.Log(dialoguestartline);
            string dialogueBlock = null;
            
            dialogueBlock = dialogueFile.text.Substring(dialoguestartline, dialogueFile.text.IndexOf("<el>", dialoguestartline) + 4);

            lines = dialogueBlock.Split('\n');
        }
            lines[lineNum] = lines[lineNum].Trim(' ', '\n', '\r');

            Debug.Log(lines[lineNum]);
            dialogueLine = lines[lineNum];
    }
}
    

