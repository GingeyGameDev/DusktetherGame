using UnityEngine;
using UnityEngine.UI;


public class DialogueStart : MonoBehaviour
{
   public GameObject dialogueManagerObject;

   public GameObject textBox;

   Dialogue dialogueScript;
   DialogueManager dialogueManager;
   PlayerMovement playerMovement;

    void Awake() 
    {
       
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();

    }
 
    public void dialogueStart(string direction, GameObject interactedObject) 
    {
        dialogueScript = interactedObject.GetComponentInParent<Dialogue>();

        if (dialogueScript.dialogueText.text != "" || dialogueScript.dialogueText.text != null)
        {
            textBox.SetActive(true);

            if (dialogueScript.charName != "" && dialogueScript.objectName != "")
            {
                Debug.Log("Incorrect Interaction Name Inputted");
            }
            //if the character has a name
            else if (dialogueScript.charName != "")
            {
                characterDialogue(direction, interactedObject);
            }
            //if the object has a name
            else if (dialogueScript.objectName != "")
            {
                objectDialogue(direction, interactedObject);
            }
        }
    }

    void characterDialogue(string direction, GameObject interactedObject) 
    {
        Debug.Log("character dialogue " + direction);
        dialogueManager.GetDialogue(dialogueScript.charName,null, interactedObject, dialogueScript.dialogueText);
        
    }

    void objectDialogue(string direction, GameObject interactedObject) 
    {
        Debug.Log(dialogueScript.objectName + " dialogue " + direction);

         dialogueManager.GetDialogue(dialogueScript.charName, dialogueScript.objectName, interactedObject, dialogueScript.dialogueText);
       
    }
}
