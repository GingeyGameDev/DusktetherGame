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

    private TextAsset dialogueFile;
    private string charNameManager = "";
    private string objectNameManager = "";

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        dialogueReader = FindObjectOfType<DialogueReader>();
        dialogue.text = "";


        lineNumber = 0;
        
    }

    public void GetDialogue(string charName, string objectName, TextAsset dialogueText)
    {
        if (charName != null)
        {
            charNameManager = charName;
        }
        else { charNameManager = null;}

        if (dialogueText != null)
        {
            dialogueFile = dialogueText;
        }
        else { dialogueFile = null;}

        if (objectNameManager != null)
        {
            objectNameManager = objectName;
        }
        else { objectNameManager = null;}

        dialogueReader.ReadLine(dialogueFile, lineNumber);
    }

    private void Update()
    {
        if (dialogueReader.dialogueLine != "" && Input.GetButtonDown("confirm"))
        {
            
            dialogueReader.ReadLine(dialogueFile, lineNumber);
            lineNumber++;
        }
        if (dialogueReader.dialogueLine == "<el>" || dialogueReader.dialogueLine == "<el>") 
        {
            textBox.gameObject.SetActive(false);
            playerMovement.playerMoveable = true;
            lineNumber = 0;
            dialogueFile = default;
        }
        dialogue.text = dialogueReader.dialogueLine;
    }

   

}
