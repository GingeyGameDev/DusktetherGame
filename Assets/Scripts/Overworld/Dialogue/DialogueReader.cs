using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{

    [HideInInspector]
    public string[] lines;

    string objectName;

    [HideInInspector]
    public string dialogueLine;

    public int lineNum = 0;

    public float scrollTime;

    [HideInInspector]
    public bool skip;

    DialogueManager dialogueManager;
    FaceEmotion faceEmotion;

    public string dialogueBlock;

    private void Start()
    {
        dialogueManager = gameObject.GetComponent<DialogueManager>();
        faceEmotion = gameObject.GetComponent<FaceEmotion>();
    }

    public void lineInitialization(TextAsset dialogueFile, string name, int timesInteracted)
    {
        objectName = name;

        lineNum = 0;

        int dialogueStartLine = 0;

        dialogueStartLine = dialogueFile.text.IndexOf('<' + name + '-' + timesInteracted + '>');

        dialogueBlock = null;

        dialogueBlock = dialogueFile.text.Substring(dialogueStartLine, (dialogueFile.text.IndexOf(("<el>"), dialogueStartLine) - dialogueStartLine + 4));

        lines = dialogueBlock.Split('\n');

        ReadLine(lines, timesInteracted);
    }

    public void ReadLine(string[] lines, int timesInteracted)
    {
        faceEmotion.lineEnded = false;

        lines[lineNum] = lines[lineNum].Trim(' ', '\n', '\r');
        dialogueLine = lines[lineNum];
       

        if (dialogueLine.Equals("<" + objectName + "-" + timesInteracted + ">"))
            {
                lineNum++;
                ReadLine(lines, timesInteracted);

            }
            else
            {
               if (dialogueLine == "<rl>")
                {
                    lineNum++;

                    dialogueManager.StartCoroutine("DialogueEnd", true);
                }

                else if (dialogueLine == "<el>")
                {
                    dialogueManager.StartCoroutine("DialogueEnd", false);
                }

               else StartCoroutine(TextScroll(scrollTime));
            }

        if (dialogueLine.StartsWith("<f"))
        {
            emotionCheck(dialogueLine);
        } 
    }
    

    public void emotionCheck(string line)
    {
        //face
        switch (line.Substring(2,1))
        { 
            case "h":
                faceEmotion.Emotion("happy");
                break;

            case "s":
                faceEmotion.Emotion("sad");
                break;

            case "a":
                faceEmotion.Emotion("angry");
                break;

            case "e":
                faceEmotion.Emotion("excited");
                break;

            case "1":
                faceEmotion.Emotion("special1");
                break;

            case "2":
                faceEmotion.Emotion("special2");
                break;

            case "3":
                faceEmotion.Emotion("special3");
                break;

            default:
                Debug.Log("Error: Dialogue Reader \n | No Face Found");
                break;

        }
        dialogueLine = dialogueLine.Substring(4, dialogueLine.Length - 4);
    }


    public IEnumerator TextScroll(float waitTime) 
    {
       
        dialogueManager.lineStartTime = Time.time;

        string tempLine = null;

            for (var i = 0; i <= dialogueLine.Length; i++)
            {
            if (skip)
            {
                tempLine = dialogueLine;
                dialogueManager.dialogue.text = tempLine;
                faceEmotion.lineEnded = true;
                yield return new WaitForEndOfFrame();
                break;

            }
            else 
            {

                tempLine = dialogueLine.Substring(0, i);
                dialogueManager.dialogue.text = tempLine;

            }



            yield return new WaitForSecondsRealtime(scrollTime);
            yield return new WaitForEndOfFrame();
           
             }
        skip = false;

        faceEmotion.lineEnded = true;

    }
}


    

