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

            int dialogueStartLine = 0;

            dialogueStartLine = dialogueFile.text.IndexOf('<' + name + '-' + timesInteracted + '>');


          Debug.Log('<' + name + '-' + timesInteracted + '>');

            string dialogueBlock = null;

            dialogueBlock = dialogueFile.text.Substring(dialogueStartLine, (dialogueFile.text.IndexOf(("<el>"), dialogueStartLine)-dialogueStartLine + 4));

            lines = dialogueBlock.Split('\n');


            lines[lineNum] = lines[lineNum].Trim(' ', '\n', '\r');

            

            dialogueLine = lines[lineNum];

            if (dialogueLine == ('<' + name + '-' + timesInteracted + '>'))
            {
                lineNum++;
                ReadLine(dialogueFile, name, timesInteracted);
            }

            if (dialogueLine == "<rl>") 
            {
                lineNum++;
                timesInteracted = timesInteracted - 1;
                ReadLine(dialogueFile, name, timesInteracted);
            }

            Debug.Log(dialogueLine);


            if (dialogueLine == "<el>" || dialogueLine == "<rl>")
            {

               /* if (dialogueLine == "<rl>") 
                {
                    dialogueManager.StartCoroutine("DialogueEnd", true);
                } */
                dialogueManager.StartCoroutine("DialogueEnd", false);
            }
            dialogueManager.TextUpdate();

            
        }
        else 
        {
            Debug.Log("Dialogue file is null");
        }
    } 
}
    

