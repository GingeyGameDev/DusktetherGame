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
    FaceEmotion faceEmotion;

    private void Start()
    {
        dialogueManager = gameObject.GetComponent<DialogueManager>();
        faceEmotion = gameObject.GetComponent<FaceEmotion>();
    }

    public void ReadLine(TextAsset dialogueFile, string name, int timesInteracted)
    {


        if (dialogueFile != null)
        {

            int dialogueStartLine = 0;

            dialogueStartLine = dialogueFile.text.IndexOf('<' + name + '-' + timesInteracted + '>');


            //Debug.Log('<' + name + '-' + timesInteracted + '>');

            string dialogueBlock = null;

            dialogueBlock = dialogueFile.text.Substring(dialogueStartLine, (dialogueFile.text.IndexOf(("<el>"), dialogueStartLine) - dialogueStartLine + 4));

            lines = dialogueBlock.Split('\n');


            lines[lineNum] = lines[lineNum].Trim(' ', '\n', '\r');



            dialogueLine = lines[lineNum];

            if (dialogueLine.StartsWith("<fh>"))
            {

                dialogueLine = lines[lineNum].Substring(4, dialogueLine.Length - 4);

                faceEmotion.Emotion("happy");

            } else if (dialogueLine.StartsWith("<fs>"))
            {
                dialogueLine = lines[lineNum].Substring(4, dialogueLine.Length - 4);

                faceEmotion.Emotion("sad");
            }



            if (dialogueLine == ('<' + name + '-' + timesInteracted + '>'))
            {
                lineNum++;
                ReadLine(dialogueFile, name, timesInteracted);

            }
            else{ 




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


                StartCoroutine(TextScroll(scrollTime));


            }
    }
    else 
    {
       Debug.Log("Dialogue file is null");
    }
    }
    public IEnumerator TextScroll(float waitTime) 
    {
       

        dialogueManager.lineStartTime = Time.time;

        string tempLine = null;

        faceEmotion.lineEnded = false;


            for (var i = 0; i <= dialogueLine.Length; i++)
            {


                tempLine = dialogueLine.Substring(0, i);
                dialogueManager.TextUpdate(tempLine);
            if (skip) 
                {
                    tempLine = dialogueLine;
                    dialogueManager.TextUpdate(tempLine);
                
                    break;
                
                }
            
            yield return new WaitForSecondsRealtime(scrollTime);
           
        }
        skip = false;


        faceEmotion.lineEnded = true;
    }
}


    

