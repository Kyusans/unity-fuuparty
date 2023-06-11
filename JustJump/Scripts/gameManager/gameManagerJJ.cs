using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManagerJJ : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerFinalScoreText;
    [SerializeField] Text playerScoreText;
    [SerializeField] GameObject gameOverScene;
    [SerializeField] PlayerLeaderboardScript playerLeaderboardScript;
    [SerializeField] Animator cameraAnimator;
    public int playerScore = 0; 

    private void Update(){
        playerScoreText.text = playerScore.ToString();

        if(playerScore >= 10){
            cameraAnimator.enabled = true;
        } 
    }

    public void gameOver(){
        if(PlayerPrefs.GetString("currentRoom") == "0"){
            highScoreEvaluation("playerHighScoreJustJump");
        }else{
            highScoreEvaluation(PlayerPrefs.GetString("currentRoom"));
        }
        playerScoreText.enabled = false;
        gameOverScene.SetActive(true);
        playerLeaderboardScript.muteBGM();
    }

    void highScoreEvaluation(string highScoreString)
    {
        if(playerScore > PlayerPrefs.GetInt(highScoreString))
        {
            PlayerPrefs.SetInt(highScoreString, playerScore);
            playerLeaderboardScript.savePlayerScoreRankings();
        }

        playerFinalScoreText.text = "Score\n" + playerScore + "\nHigh Score\n" + PlayerPrefs.GetInt(highScoreString);
        
        // if((int)secondsCount == 69)
        // {
        //     Invoke("fuuAnimatorTrue", 0.6f);
        // }
    } 
}
