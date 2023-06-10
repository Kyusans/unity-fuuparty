using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScriptFD : MonoBehaviour
{
    float speed;
    void Start(){
        Destroy(gameObject, 5f);
        speed = FindObjectOfType<spawnerFD>().obstacleSpeed;
    }

    void Update(){
        transform.Translate(Vector2.down * speed * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player"){
            gameObject.SetActive(false);
        }
    }
}
