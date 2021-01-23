using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceEmotion : MonoBehaviour
{
    public GameObject face;

    public Image faceRenderer;


    public Sprite[] faceSprites;

    public int choosenFrame;
    public float animationTime;

    public bool lineEnded;

    // Start is called before the first frame update
    void Start()
    {
        faceRenderer = face.GetComponent<Image>();
        lineEnded = false;
    }



    public void Emotion(string emotion) 
    {
        StopCoroutine(EmotionsAnimator(0));


        if (emotion == "happy")
        {
            // StartCoroutine(EmotionsAnimator(0));
            faceRenderer.sprite = faceSprites[0];
        }
        else if (emotion == "sad") 
            {
            faceRenderer.sprite = faceSprites[1];

            // StartCoroutine(EmotionsAnimator(1));
        }


    }

    public IEnumerator EmotionsAnimator(int frame1 , int frame2 = -1)
    {

        while (!lineEnded) 
        {
            faceRenderer.sprite = faceSprites[frame1];

            if (frame2 != -1)
            {
           
                yield return new WaitForSeconds(animationTime);

                faceRenderer.sprite = faceSprites[frame2];

                
            }
            yield return new WaitForSeconds(animationTime);
        }

        

    }
}
