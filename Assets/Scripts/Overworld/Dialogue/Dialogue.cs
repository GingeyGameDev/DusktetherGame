using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string objectName = null;

    public bool isCharacter = false;

    public Sprite[] faceSprites;

    public int timesInteracted = 0;

    public TextAsset dialogueText = default;
    

}
