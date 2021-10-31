using UnityEngine;

public class Interacted : MonoBehaviour
{
    GameObject interactedGameObject;
    DialogueManager dialogueManager;
    Dialogue dialogue = null;

    Interaction interaction;
    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        interaction = GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>();


    }

    public void InteractCheck () 
    {
        
            //the gameobject hit by the raycast in Interaction
            interactedGameObject = interaction.interactable.collider.gameObject;
            dialogueManager.interactedObject = interactedGameObject;

            dialogue = interactedGameObject.GetComponentInParent<Dialogue>();


            //Right
            if (interaction.dirOffSet.x >= 0.5f)
            {
               
                RightFace();
            }
            //Left
            else if (interaction.dirOffSet.x <= -0.5f)
            {
                LeftFace();
            }
            //Up
            else if (interaction.dirOffSet.y >= 0.5f)
            {
                UpFace();
            }
            //Down
            else if (interaction.dirOffSet.y <= -0.5f) 
            {
                DownFace();
            }
        }   

    void UpFace() 
    {
        //dialogueStart takes the game object and the direction faced
        
        if (dialogue.isCharacter)
        {
            dialogueManager.CharacterDialogue();
        }
        else 
        {
            dialogueManager.ObjectDialogue();
        }

        dialogueManager.GetDialogue("up");
    }

    void DownFace() 
    {
        //dialogueStart takes the game object and the direction faced
        
        if (dialogue.isCharacter)
        {
            dialogueManager.CharacterDialogue();
        }
        else
        {
            dialogueManager.ObjectDialogue();
   
        }

        dialogueManager.GetDialogue("down");
    }

    void RightFace() 
    {
        //dialogueStart takes the game object and the direction faced
        
        if (dialogue.isCharacter)
        {
            dialogueManager.CharacterDialogue();
        }
        else
        {
            dialogueManager.ObjectDialogue();
        }

        dialogueManager.GetDialogue("right");
    }

    void LeftFace() 
    {
        //dialogueStart takes the game object and the direction faced
        
        if (dialogue.isCharacter)
        {
            dialogueManager.CharacterDialogue();
        }
        else
        {
            dialogueManager.ObjectDialogue();
        }

        dialogueManager.GetDialogue("left");
    }
}
