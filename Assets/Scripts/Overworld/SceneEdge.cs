using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEdge : MonoBehaviour
{
    [SerializeField]
    private string nextScene;

    [SerializeField] 
    private Vector2 scenePosition;


    public GameObject mainCam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            StartCoroutine("SceneTransition");
        }
    }

    private IEnumerator SceneTransition() 
    {
        string previousScene = SceneManager.GetActiveScene().name;

        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene(nextScene);

       // yield return new WaitUntil(SceneManager.
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));

        

        Instantiate(player, scenePosition, Quaternion.identity);
        Instantiate(mainCam, scenePosition, Quaternion.identity);

        yield return new WaitForSeconds(1);

        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(previousScene));



    }
}
