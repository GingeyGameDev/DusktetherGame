using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    
    public string[] lines;

    public string dialogueLine;
    public int lineNum = 0;

    public float scrollTime;
    public bool skip;

    DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void ReadLine(TextAsset dialogueFile, string name, int timesInteracted)
    {
        skip = false;

        if (dialogueFile != null)
        {

            int dialogueStartLine = 0;

            dialogueStartLine = dialogueFile.text.IndexOf('<' + name + '-' + timesInteracted + '>');


          //Debug.Log('<' + name + '-' + timesInteracted + '>');

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

            if (dialogueLine.StartsWith("<eh>")) 
            { 
            
            }

            

            if (dialogueLine == "<rl>") 
            {
                lineNum++;

                dialogueManager.StartCoroutine("DialogueEnd", true);
            }

         //   Debug.Log(dialogueLine);


            if (dialogueLine == "<el>")
            {
                dialogueManager.StartCoroutine("DialogueEnd", false);
            }

            StartCoroutine("TextScroll", scrollTime);
            
        }
        else 
        {
            Debug.Log("Dialogue file is null");
        }
    }
    public IEnumerator TextScroll(float waitTime) 
    {
        string tempLine = null;

            for (var i = 0; i <= dialogueLine.Length; i++)
            {


                tempLine = dialogueLine.Substring(0, i);
                dialogueManager.TextUpdate(tempLine);
                if(skip) 
                {
                    tempLine = dialogueLine;
                    dialogueManager.TextUpdate(tempLine);
                    break;
                }
                yield return new WaitForSecondsRealtime(scrollTime);

            }
        }
    }


    

