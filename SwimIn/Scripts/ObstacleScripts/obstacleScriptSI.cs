using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScriptSI : MonoBehaviour
{
    float obstacleSpeedMain;
    void Start()
    {
        Destroy(gameObject, 9f);
        obstacleSpeedMain = FindObjectOfType<ObstacleSpawnerSI>().obstacleSpeed;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * obstacleSpeedMain * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(transform.tag == "bubble"){
            if(other.transform.tag == "Player")
            {
                gameObject.SetActive(false);
            }
            else if(other.transform.tag == "obstacle")
            {
                transform.position = new Vector2(2,0);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(transform.tag == "obstacle")
        {
            if(other.transform.tag == "bubble")
            {
                Destroy(gameObject);
            }
        }    
    }

    
}