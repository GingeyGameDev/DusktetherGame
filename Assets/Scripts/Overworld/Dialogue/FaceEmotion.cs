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
          //  faceRenderer.sprite = faceSprites[0];
             StartCoroutine(EmotionsAnimator(0,1));
            
        }
            else if (emotion == "sad")
            {
              //  faceRenderer.sprite = faceSprites[1];

                 StartCoroutine(EmotionsAnimator(2,3));
               
            }
                else if (emotion == "angry")
                {
                  //  faceRenderer.sprite = faceSprites[2];

                     StartCoroutine(EmotionsAnimator(4,5));
                     

                }
                    else if (emotion == "special1")
                    {
                       // faceRenderer.sprite = faceSprites[3];

                         StartCoroutine(EmotionsAnimator(6,7));


                    }
                        else if (emotion == "special2")
                        {
                          //  faceRenderer.sprite = faceSprites[4];

                             StartCoroutine(EmotionsAnimator(8,9));


                        }
                            else if (emotion == "special3")
                            {
                               // faceRenderer.sprite = faceSprites[5];

                                 StartCoroutine(EmotionsAnimator(10,11));


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

            if (lineEnded) 
            {
                yield break;
            }

            yield return new WaitForSeconds(animationTime);
        }

       // faceRenderer.sprite = faceSprites[frame1];

        StopCoroutine(EmotionsAnimator(0,0));

    }
}
