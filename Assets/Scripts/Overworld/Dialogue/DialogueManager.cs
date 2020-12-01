using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    DialogueReader dialogueReader;

    int lineNumber = 0;

    public TMP_Text dialogue;
    public GameObject textBox;

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

    }

    public void GetDialogue(string direction, GameObject interactedObject)
    {

        dialogueScript = interactedObject.GetComponent<Dialogue>();

        textBox.SetActive(true);

        if (dialogueScript.charName != "" && dialogueScript.objectName != "")
        {
            Debug.Log("Incorrect Interaction Name Inputted");
        }

        if (dialogueScript.charName != "")
        {
            nameManager = dialogueScript.charName;
            Debug.Log(nameManager + "dialogue " + direction);

        }
        else if (dialogueScript.objectName != null)
        {
           nameManager = dialogueScript.objectName;
            Debug.Log(nameManager + " dialogue " + direction);

        }
        else {nameManager = null;}

        dialogueFile = dialogueScript.dialogueText;


        dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
        


    }

    private void Update()
    {
        if (dialogueReader.dialogueLine != "" && Input.GetButtonDown("confirm"))
        {
            dialogueReader.lineNum++;
            dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
            
            
           
        }
     
        dialogue.text = dialogueReader.dialogueLine;
    }

    public void DialogueEnd() 
    {
        textBox.SetActive(false);

        dialogueScript.timesInteracted++;
        dialogueFile = default;
        playerMovement.playerMoveable = true;
        dialogueReader.lineNum = 0;
    }

}
