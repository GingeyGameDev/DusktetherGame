using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{

    DialogueReader dialogueReader;

    public bool skipable;

    public TMP_Text dialogue;
    RectTransform textRect;
    public GameObject textBox;

    public GameObject characterDialogue;

    public Sprite charTextBox;
    public Sprite objectTextBox;

   

    PlayerMovement playerMovement;
    Dialogue dialogueScript;
    FaceEmotion faceEmotion;

    [SerializeField]
    private TextAsset dialogueFile;
    private string nameManager = "";

    [HideInInspector]
    public float lineStartTime;
    public float InputWaitTime;

    public GameObject interactedObject;

    public static DialogueManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)


            instance = this;


        else if (instance != this)


            Destroy(gameObject);

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        dialogueReader = FindObjectOfType<DialogueReader>();
        
        dialogue.text = "";

        textRect = dialogue.gameObject.GetComponent<RectTransform>();

        skipable = true;

        faceEmotion = gameObject.GetComponent<FaceEmotion>();

    }



    //gets all important info for reading a line
    public void GetDialogue(string direction)
    {

        //get the dialogue script off of the interacted object
        dialogueScript = interactedObject.GetComponentInParent<Dialogue>();
        dialogueFile = dialogueScript.dialogueText;

        //activate text box and child gameobjects
        textBox.SetActive(true);

        nameManager = dialogueScript.objectName;

        faceEmotion.faceSprites = dialogueScript.faceSprites;

        //if no dialogue file is found
        if (dialogueFile == null) { Debug.Log("file missing manager"); }

        //starts the reading of the file with the name and the times interacted
        dialogueReader.lineInitialization(dialogueFile, nameManager, dialogueScript.timesInteracted);

    }

        //initialization

    public void CharacterDialogue()
    {
        textBox.GetComponent<Image>().sprite = charTextBox;

        characterDialogue.SetActive(true);
        characterDialogue.GetComponentInChildren<TMP_Text>().text = nameManager;

        textRect.sizeDelta = new Vector2(545, 80);
        textRect.anchoredPosition = new Vector2(68, 0);
    }

    public void ObjectDialogue()
    {
        textBox.GetComponent<Image>().sprite = objectTextBox;


        textRect.sizeDelta = new Vector2(666, 160);
        textRect.anchoredPosition = new Vector2(0, 0);
    }

    


    void Update() 
    {
        if (Input.GetButtonDown("confirm") && (Time.time > (lineStartTime + InputWaitTime)) && playerMovement.playerMoveable == false && skipable) 
        {
            if (dialogue.text != dialogueReader.dialogueLine)
            {
                dialogueReader.skip = true;
               
            }
            else if (dialogue.text == dialogueReader.dialogueLine && Time.time > (lineStartTime + (InputWaitTime * 2)))
            {
                dialogueReader.skip = false;
                dialogueReader.lineNum++;
                dialogueReader.ReadLine(dialogueReader.lines, dialogueScript.timesInteracted);
            }
        } 
    }

        //called to close the dialogue
        public IEnumerator DialogueEnd(bool removeOne)
        {
            //Debug.Log("end dialogue");

            characterDialogue.SetActive(false);
            textBox.SetActive(false);


            dialogueFile = default;

            if (!removeOne)
            {
                dialogueScript.timesInteracted++;
            }
            dialogueReader.lineNum = 0;
            yield return new WaitForEndOfFrame();
            playerMovement.playerMoveable = true;
        }


    }

