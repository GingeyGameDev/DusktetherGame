﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerRendering : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //if the position of the player is less than the position of the object + its collider size on the x, for both right and left bounds of the object 
        if (player.transform.position.x <= (gameObject.transform.position.x + gameObject.GetComponent<Collider2D>().bounds.size.x) && player.transform.position.x >= (gameObject.transform.position.x - gameObject.GetComponent<Collider2D>().bounds.size.x)) 
        {

            //y of the player + its offset + its collider size on y, is greater than the object + its collider offset
            if ((player.transform.position.y + (player.GetComponent<Collider2D>().offset.y - player.GetComponent<Collider2D>().bounds.size.y)) > (gameObject.transform.position.y + (gameObject.GetComponent<Collider2D>().offset.y))) //+ gameObject.GetComponent<Collider2D>().bounds.size.y)))
            {
               
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Object Tops";
            }
            else 
            {
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = default;
            }
        }
        

    }
}
