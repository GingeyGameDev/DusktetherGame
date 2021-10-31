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

    [HideInInspector]
    public bool lineEnded;

    // Start is called before the first frame update
    void Start()
    {
        faceRenderer = face.GetComponent<Image>();
        lineEnded = false;
    }

    public void Emotion(string emotion)
    {
        StopAllCoroutines();

        switch (emotion)
        {
            case "happy":
                //  faceRenderer.sprite = faceSprites[0];
                StartCoroutine(EmotionsAnimator(0, 1));
                break;

            case "sad":
                //  faceRenderer.sprite = faceSprites[1];

                StartCoroutine(EmotionsAnimator(2, 3));
                break;

            case "angry":
                //  faceRenderer.sprite = faceSprites[2];

                StartCoroutine(EmotionsAnimator(4, 5));
                break;

            case "special1":
                // faceRenderer.sprite = faceSprites[3];

                StartCoroutine(EmotionsAnimator(6, 7));
                break;

            case "special2":
                //  faceRenderer.sprite = faceSprites[4];

                StartCoroutine(EmotionsAnimator(8, 9));
                break;

            case "special3":
                // faceRenderer.sprite = faceSprites[5];

                StartCoroutine(EmotionsAnimator(10, 11));
                break;

            default:
                Debug.Log("Face Emotion: /n | Face not found");
                break;
        }
    }
    public IEnumerator EmotionsAnimator(int frame1 , int frame2)
    {

        while (!lineEnded) 
        {
            faceRenderer.sprite = faceSprites[frame1];

            if (frame2 != -1)
            {
           
                yield return new WaitForSeconds(animationTime + Time.deltaTime);

                faceRenderer.sprite = faceSprites[frame2];

                
            }

            if (lineEnded) 
            {
                yield break;
            }

            yield return new WaitForSeconds(animationTime + Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        // faceRenderer.sprite = faceSprites[frame1];
        yield return new WaitForFixedUpdate();

        StopAllCoroutines();

    }
}
