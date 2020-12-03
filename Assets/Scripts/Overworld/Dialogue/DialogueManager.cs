using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{

    DialogueReader dialogueReader;


    public TMP_Text dialogue;
    public GameObject textBox;

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

    }

    public void GetDialogue(string direction, GameObject interactedObject)
    {
        playerMovement.playerMoveable = false;


        dialogueScript = interactedObject.GetComponent<Dialogue>();
        dialogueFile = dialogueScript.dialogueText;
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
          //  Debug.Log(nameManager + " dialogue " + direction);

        }
        else {nameManager = null;}


        if (dialogueFile == null) { Debug.Log("file missing manager"); }


        dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
        


    }

    public void TextUpdate() 
    {
        dialogue.text = dialogueReader.dialogueLine;
    }

    private void Update()
    {
        if (dialogueFile != null  && Input.GetButtonDown("confirm"))
        {
            dialogueReader.lineNum++;
            dialogueReader.ReadLine(dialogueFile, nameManager, dialogueScript.timesInteracted);
            
            
           
        }
     
        
    }

    public IEnumerator DialogueEnd() 
    {
        Debug.Log("end dialogue");
        
        textBox.SetActive(false);

        
        dialogueFile = default;
        
        dialogueScript.timesInteracted++;
        dialogueReader.lineNum = 0;
        yield return new WaitForEndOfFrame();
        playerMovement.playerMoveable = true;
    }

}
