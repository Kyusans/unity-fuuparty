using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingBoxScript : MonoBehaviour
{
    [SerializeField] playerScriptJJ playerScriptJJ;
    float obstacleSpeed = 1f;
    float randomPositionY;
    private void Start() {
        randomPositionY = Random.Range(-2.89f, -1.02f);
        transform.position = new Vector2(transform.position.x, randomPositionY);
    }

    private void FixedUpdate() {
        if(playerScriptJJ.playerJumped && playerScriptJJ.gameOver == false){
            transform.Translate(new Vector3(-obstacleSpeed * Time.deltaTime, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "obstacleReset"){
            Destroy(gameObject);
        }
    }
}
