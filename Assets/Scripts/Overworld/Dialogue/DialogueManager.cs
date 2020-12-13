﻿using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{

    DialogueReader dialogueReader;


    public TMP_Text dialogue;
    RectTransform textRect;
    public GameObject textBox;

    public Sprite charTextBox;
    public Sprite objectTextBox;

    PlayerMovement playerMovement;
    Dialogue dialogueScript;

    [SerializeField]
    private TextAsset dialogueFile;
    private string nameManager = "";
    
    
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        dialogueReader = FindObjectOfType<DialogueReader>();
        dialogue.text = "";

        textRect = dialogue.gameObject.GetComponent<RectTransform>();

    }

    public void GetDialogue(string direction, GameObject interactedObject)
    {
        playerMovement.playerMoveable = false;


        dialogueScript = interactedObject.GetComponentInParent<Dialogue>();
        dialogueFile = dialogueScript.dialogueText;
        textBox.SetActive(true);

        if (dialogueScript.charName != "" && dialogueScript.objectName != "")
        {
            Debug.Log("Incorrect Interaction Name Inputted");
        }

        if (dialogueScript.charName != "")
        {
            nameManager = dialogueScript.charName;
            CharacterDialogue();

            Debug.Log(nameManager + "dialogue " + direction);

        }
        else if (dialogueScript.objectName != null)
        {
           nameManager = dialogueScript.objectName;
            ObjectDialogue();

           Debug.Log(nameManager + " dialogue " + direction);

        }
        else {nameManager = null;}


        if (dialogueFile == null) { Debug.Log("file missing manager"); }


        dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
        


    }

    public void TextUpdate(string tempLine) 
    {
        dialogue.text = tempLine;

    }

    private void Update()
    {
        
        if (playerMovement.playerMoveable == false && Input.GetButtonDown("confirm"))

        {
           
            dialogueReader.scrollTime = 0.01f;
            if (dialogue.text == dialogueReader.dialogueLine)
            {
                dialogueReader.lineNum++;
                dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
            }
            
           
        }
     
        
    }

    public IEnumerator DialogueEnd(bool removeOne) 
    {
        Debug.Log("end dialogue");
        
        textBox.SetActive(false);

        
        dialogueFile = default;

        if (!removeOne) 
        {
            dialogueScript.timesInteracted++;
        }
        dialogueReader.lineNum = 0;
        yield return new WaitForEndOfFrame();
        playerMovement.playerMoveable = true;
    }

    public void CharacterDialogue () 
    {
        textBox.GetComponent<Image>().sprite = charTextBox;
    }

    public void ObjectDialogue() 
    {
        textBox.GetComponent<Image>().sprite = objectTextBox;

        
        textRect.sizeDelta = new Vector2 (666,160);

    }
}
