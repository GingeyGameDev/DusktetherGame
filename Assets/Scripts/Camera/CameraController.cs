using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;

    public float followSpeed;

    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.playerMoveable == true) 
        {

            if (mainCamera.transform.position != target.transform.position)
            {
                mainCamera.transform.Translate(new Vector3((target.transform.position.x - mainCamera.transform.position.x), (target.transform.position.y - mainCamera.transform.position.y), 0));
            }
        }
    }

    public void PanCamera(GameObject target) 
    {
        mainCamera.transform.Translate(new Vector3((target.transform.position.x - mainCamera.transform.position.x), (target.transform.position.y - mainCamera.transform.position.y), 0) * Time.deltaTime * followSpeed);
    }
}
