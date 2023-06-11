using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addScoreScript : MonoBehaviour
{
    [SerializeField] gameManagerJJ gameManagerJJ;
    [SerializeField] obstacleScriptJJ obstacleScriptJJ;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Player" && obstacleScriptJJ.playerScored == false){
            SoundManager.playSound("coinCollected");
            obstacleScriptJJ.playerScored = true;
            gameManagerJJ.playerScore++;
        }
    }
}
