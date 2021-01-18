using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{

    DialogueReader dialogueReader;


    public TMP_Text dialogue;
    RectTransform textRect;
    public GameObject textBox;

    public GameObject characterDialogue;

    public Sprite charTextBox;
    public Sprite objectTextBox;

    PlayerMovement playerMovement;
    Dialogue dialogueScript;

    [SerializeField]
    private TextAsset dialogueFile;
    private string nameManager = "";
    
    

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        dialogueReader = FindObjectOfType<DialogueReader>();
        dialogue.text = "";

        textRect = dialogue.gameObject.GetComponent<RectTransform>();

    }

    //gets all important info for reading a line
    public void GetDialogue(string direction, GameObject interactedObject)
    {

        //get the dialogue script off of the interacted object
        dialogueScript = interactedObject.GetComponentInParent<Dialogue>();
        dialogueFile = dialogueScript.dialogueText;

        //activate text box and child gameobjects
        textBox.SetActive(true);


        //debug: if someone made an oopsie and entered names in both places
        if (dialogueScript.charName != "" && dialogueScript.objectName != "")
        {
            Debug.Log("Incorrect Interaction Name Inputted");
        }

        //if name is inputted in the character slot, the function for the character dialogue is called
        if (dialogueScript.charName != "")
        {
            nameManager = dialogueScript.charName;
            CharacterDialogue();

           // Debug.Log(nameManager + "dialogue " + direction);

        }

        //if name is inputted in the object slot, the function for the object dialogue is called
        else if (dialogueScript.objectName != null)
        {
           nameManager = dialogueScript.objectName;
            ObjectDialogue();

           Debug.Log(nameManager + " dialogue " + direction);

        }

        //debug
        //if no name is entered, set to null
        else {nameManager = null;}
        //if no dialogue file is found
        if (dialogueFile == null) { Debug.Log("file missing manager"); }



        //starts the reading of the file with the name and the times interacted
        dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
        


    }

    //updates the text to the dialogue line
    public void TextUpdate(string tempLine) 
    {
        dialogue.text = tempLine;

    }

    private void Update()
    {
        //if the confirm button is pressed, make the reader speed up to finish line
        //goes to next line if the line is finished

        if (playerMovement.playerMoveable == false && Input.GetButtonDown("confirm"))

        {

            dialogueReader.skip = true;
            if (dialogue.text == dialogueReader.dialogueLine)
            {
                dialogueReader.lineNum++;
                dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
            }
            
           
        } 
     
        
    }

    //called to close the dialogue
    public IEnumerator DialogueEnd(bool removeOne) 
    {
        //Debug.Log("end dialogue");

        characterDialogue.SetActive(false);
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

        characterDialogue.SetActive(true);
        characterDialogue.GetComponentInChildren<TMP_Text>().text = nameManager;

        textRect.sizeDelta = new Vector2(545, 80);
        textRect.anchoredPosition = new Vector2(68, 0);
    }

    public void ObjectDialogue() 
    {
        textBox.GetComponent<Image>().sprite = objectTextBox;

        
        textRect.sizeDelta = new Vector2 (666,160);
        textRect.anchoredPosition = new Vector2(0, 0);
    }


    //emotions

    public void Emotions(string emotion) 
    { 
    
    }


}
