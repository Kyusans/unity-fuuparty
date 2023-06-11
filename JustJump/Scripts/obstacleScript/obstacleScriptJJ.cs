using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScriptJJ : MonoBehaviour
{
    [SerializeField] playerScriptJJ playerScriptJJ;
    [SerializeField] gameManagerJJ gameManager;
    [SerializeField] GameObject boxObject;
    float obstacleDistance = 1f;
    float obstacleSpeed = 1f;
    float randomPositionY;
    public bool playerScored = false;
    private void Start() {
        randomPositionY = Random.Range(-2.2f, -0.45f);
        transform.position = new Vector2(transform.position.x, randomPositionY);
    }
    private void FixedUpdate() {
        if(playerScriptJJ.playerJumped && playerScriptJJ.gameOver == false){
            transform.Translate(new Vector3(-obstacleSpeed * Time.fixedDeltaTime, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "obstacleReset" && gameManager.playerScore >= 8){           
            obstacleChangeScale(0.35f);
            obstacleDistance = 1.1f;
        }if(other.transform.tag == "obstacleReset" && gameManager.playerScore >= 28){
            obstacleChangeScale(0.3f);
        }

        
        if(other.transform.tag == "obstacleReset"){
            randomPositionY = Random.Range(-2.2f, -0.45f);
            transform.position = new Vector2(boxObject.transform.position.x + obstacleDistance, randomPositionY);
            playerScored = false;            
        }
    }

    private void obstacleChangeScale(float obstacleX){
        transform.localScale = new Vector3(obstacleX, transform.localScale.y, transform.localScale.z);
    }
}
