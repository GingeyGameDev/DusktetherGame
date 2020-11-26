using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool enemyEncountered;
    private void Start()
    {
        enemyEncountered = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Attack")) 
        {
            enemyEncountered = true;
            Debug.Log("Enemy Encountered");
        }
    }

}
