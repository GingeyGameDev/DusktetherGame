using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;


    public float followSpeed;

    public Vector2 camMoveMin = default;
    public Vector2 camMoveMax = default;

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
                DynamicCamera();
            }
        }
    }

    public void DynamicCamera() 
    {
        target = playerMovement.gameObject;

        if (target.transform.position.x >= camMoveMin.x && target.transform.position.x <= camMoveMax.x) 
        {
            mainCamera.transform.Translate(new Vector3(target.transform.position.x - mainCamera.transform.position.x, 0.0f, 0.0f));

        }

        if (target.transform.position.y >= camMoveMin.y && target.transform.position.y <= camMoveMax.y)
        {
            mainCamera.transform.Translate(new Vector3(0.0f, target.transform.position.y - mainCamera.transform.position.y, 0.0f));

        }


    }

    public void PanCamera(GameObject target) 
    {
        mainCamera.transform.Translate(new Vector3((target.transform.position.x - mainCamera.transform.position.x), (target.transform.position.y - mainCamera.transform.position.y), 0) * Time.deltaTime * followSpeed);
    }
}
