using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    DialogueReader dialogueReader;

    int lineNumber = 0;

    public TMP_Text dialogue;
    public Image textBox;

    PlayerMovement playerMovement;
    Dialogue dialogueScript;

    private TextAsset dialogueFile;
    private string nameManager = "";
    

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        dialogueReader = FindObjectOfType<DialogueReader>();
        dialogue.text = "";


        lineNumber = 0;
        
    }

    public void GetDialogue(string charName, string objectName, GameObject interactedObject, TextAsset dialogueText)
    {
        dialogueScript = interactedObject.GetComponent<Dialogue>();

        if (charName != "")
        {
            nameManager = charName;
          
        }
        else if (objectName != null)
        {
           nameManager = objectName;

        }
        else {nameManager = null;}

      


        if (dialogueText != null)
        {
            dialogueFile = dialogueText;
        }
        else { dialogueFile = default; }

        dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted, lineNumber);
    }

    private void Update()
    {
        if (dialogueReader.dialogueLine != "" && Input.GetButtonDown("confirm"))
        {
            
            dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted, lineNumber);
            lineNumber++;
        }
        if (dialogueReader.dialogueLine == "<el>" || dialogueReader.dialogueLine == "<el>") 
        {
            textBox.gameObject.SetActive(false);
            playerMovement.playerMoveable = true;
            lineNumber = 0;
            dialogueScript.timesInteracted++; //BROKEN
            dialogueFile = default;
        }
        dialogue.text = dialogueReader.dialogueLine;
    }

   

}
