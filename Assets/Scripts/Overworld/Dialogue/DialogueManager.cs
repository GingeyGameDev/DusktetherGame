using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
   

    public TMP_Text dialogue;
    private TextAsset dialogueFile;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.text = "";
    }

    public void GetDialogue(string charName, string objectName, TextAsset dialogueText)
    {
       
        if (dialogueText != null)
        {       
            dialogueFile = dialogueText;
            dialogue.text = dialogueFile.text;
        }
    }

    private void Update()
    {
       
    }

   

}
