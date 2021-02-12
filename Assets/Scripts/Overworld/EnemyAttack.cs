using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyAttack : MonoBehaviour
{
    public GameObject enemyAttackObject;

    public GameObject world;
    private GameObject player;
    public Animator anim;

    // private Rigidbody2D worldRb;
    private SpriteRenderer enemyAttackSprite;

    private PlayerMovement playerMovement;
    private PlayerCollision playerCollision;
    private EnemyDataTransfer enemyDataTransfer;
    
    [SerializeField]
    private Object[] EnemyScripts;

    private void Start()
    {
        //find player
        if (player == null)
        {
            
            player = GameObject.FindGameObjectWithTag("Player");
        }
        anim = player.GetComponent<Animator>();

        enemyDataTransfer = FindObjectOfType<EnemyDataTransfer>();


        //assign scripts to player
        playerCollision = player.GetComponent<PlayerCollision>();
        playerMovement = player.GetComponent<PlayerMovement>();
        //world elements
        enemyAttackSprite = enemyAttackObject.GetComponent<SpriteRenderer>();
       // worldRb = world.GetComponent<Rigidbody2D>();
    }

    IEnumerator EnemyEncountered()
    {

        anim.SetBool("isMoving", false);
        anim.SetFloat("horizontalMove", 0);
        anim.SetFloat("verticalMove", 0);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Battle");
        asyncLoad.allowSceneActivation = false;

        enemyDataTransfer.dataTransfer(EnemyScripts);
        
        //bring sprite forward
        enemyAttackSprite.sortingOrder = 1;

        //move player centered and disable movement
        
        playerMovement.playerMoveable = false;


        yield return new WaitForSecondsRealtime(0);

        asyncLoad.allowSceneActivation = true;
        
        
    }



    public void Update()
    {
        if (playerCollision.enemyEncountered == true) 
        {
            StartCoroutine("EnemyEncountered");
            playerCollision.enemyEncountered = false;

          
        }
    }
}
    
