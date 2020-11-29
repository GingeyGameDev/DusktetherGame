using UnityEngine;

public class Interacted : MonoBehaviour
{
    GameObject interactedGameObject;
    DialogueStart dialogueStart;

    Interaction interaction;
    private void Start()
    {
        dialogueStart = FindObjectOfType<DialogueStart>();
        interaction = GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>();
    }

    public void Update () 
    {
        //Change - make function called in interaction instead of using update
        if (interaction.interactCheck) 
        {
            interaction.interactCheck = false;

            //the gameobject hit by the raycast in Interaction
            interactedGameObject = interaction.interactable.collider.gameObject;

          // dialogueStart.gameObject.SetActive(true);

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
    }

    void UpFace() 
    {
        //dialogueStart takes the game object and the direction faced
        dialogueStart.dialogueStart("up", interactedGameObject);
        
    }

    void DownFace() 
    {
        //dialogueStart takes the game object and the direction faced
        dialogueStart.dialogueStart("down", interactedGameObject);
    }

    void RightFace() 
    {
        //dialogueStart takes the game object and the direction faced
        dialogueStart.dialogueStart("right", interactedGameObject);
    }

    void LeftFace() 
    {
        //dialogueStart takes the game object and the direction faced
        dialogueStart.dialogueStart("left", interactedGameObject);
    }
}
