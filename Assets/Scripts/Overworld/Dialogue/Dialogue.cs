﻿using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string charName = null;
    public string objectName = null;
    public Animation Charanimation;

    public int timesInteracted = 0;

    public TextAsset dialogueText = default;
    
}
