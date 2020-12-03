using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    
    public string[] lines;

    public string dialogueLine;
    public int lineNum = 0;

    DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void ReadLine(TextAsset dialogueFile, string name, int timesInteracted)
    {
        if (dialogueFile != null)
        {
           


            int dialoguestartline = dialogueFile.text.IndexOf('<' + name + '-' + timesInteracted + '>');


          //  Debug.Log('<' + name + '-' + timesInteracted + '>');

            string dialogueBlock = null;

            dialogueBlock = dialogueFile.text.Substring(dialoguestartline, dialogueFile.text.IndexOf("<el>", dialoguestartline) + 4);

            lines = dialogueBlock.Split('\n');


            lines[lineNum] = lines[lineNum].Trim(' ', '\n', '\r');

            

            dialogueLine = lines[lineNum];

            if (dialogueLine == ('<' + name + '-' + timesInteracted + '>'))
            {
                lineNum++;
                ReadLine(dialogueFile, name, timesInteracted);
            }

            Debug.Log(dialogueLine);


            if (dialogueLine == "<el>" || dialogueLine == "<el> ")
            {
                dialogueManager.StartCoroutine("DialogueEnd");
            }
            dialogueManager.TextUpdate();

            dialogueLine = null;
        }
        else 
        {
            Debug.Log("Dialogue file is null");
        }
    } 
}
    

