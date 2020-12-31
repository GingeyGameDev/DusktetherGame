using UnityEngine;

public class Interaction : MonoBehaviour
{
   public GameObject playerObject;
   private Animator anim;

    public float interactableDistance;

    public Vector2 dirOffSet;
    public RaycastHit2D interactable;


    PlayerMovement playerMovement;
    Interacted interacted;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = playerObject.GetComponent<PlayerMovement>();
        anim = playerObject.GetComponent<Animator>();
        interacted = FindObjectOfType<Interacted>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.playerMoveable != false) 
        {
            if (Input.GetButtonDown("confirm"))
            {
                //get last move floats and normalize
                dirOffSet = new Vector2(anim.GetFloat("horizontalMoveLast"), anim.GetFloat("verticalMoveLast"));

                //send 
                interactable = Physics2D.Raycast((Vector2)transform.position - new Vector2(0.0f, .87f), dirOffSet, interactableDistance);

                //use for debug purposes
                // Debug.DrawLine((Vector2)transform.position - new Vector2(0.0f,.87f), ((Vector2)transform.position - new Vector2(0.0f, .87f)) + (interactableDistance * dirOffset), Color.red);

                if (interactable.collider != null)
                {
                    //sets the interact bool for scripts that need it if the gameobject has the interactable tag
                    if (interactable.collider.gameObject.CompareTag("Interactable"))
                    {
                        playerMovement.playerMoveable = false;
                        interacted.InteractCheck();
                    }
                    if (interactable.collider.gameObject.CompareTag("Save")) 
                    { 
                    
                    }
                }
            }
        }
    }
}
