using UnityEngine;
using UnityEngine.UI;


public class DialogueStart : MonoBehaviour
{
   public GameObject dialogueManagerObject;

   public GameObject textBox;

   Dialogue dialogueScript;
   DialogueManager dialogueManager;


    void Awake() 
    {
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
    }
 
    public void dialogueStart(string direction, GameObject interactedObject) 
    {
        textBox.SetActive(true);

        dialogueScript = interactedObject.GetComponentInParent<Dialogue>();

        if (dialogueScript.charName != "" && dialogueScript.objectName != "")
        {
            Debug.Log("Incorrect Interaction Name Inputted");
        }
        //if the character has a name
        else if (dialogueScript.charName != "")
        {
            characterDialogue(direction);
        }
        //if the object has a name
        else if (dialogueScript.objectName != "")
        {
            objectDialogue(direction);
        }
    }

    void characterDialogue(string direction) 
    {
        Debug.Log("character dialogue " + direction);
        dialogueManager.GetDialogue(dialogueScript.charName,null, dialogueScript.dialogueText);
    }

    void objectDialogue(string direction) 
    {
        Debug.Log(dialogueScript.objectName + " dialogue " + direction);

         dialogueManager.GetDialogue(dialogueScript.charName, dialogueScript.objectName, dialogueScript.dialogueText);
       
    }
}
