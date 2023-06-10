using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerFD : MonoBehaviour
{
    [SerializeField] GameObject gameOverScene, startButtonScene, niceText;
    [SerializeField] Animator scoreAnimator;
    [SerializeField] Text highScoreText;
    [SerializeField] scoreScriptFD scoreScriptFD;
    [SerializeField] PlayerLeaderboardScript playerLeaderboardScript;
    // [SerializeField] AdsBanner adsBanner;
    public bool gameStart = false;

    public void gameOver()
    {
        playerLeaderboardScript.muteBGM();
        scoreAnimator.Play("Score_Close");
        gameOverScene.SetActive(true);
        gameStart = false;

        if(PlayerPrefs.GetString("currentRoom") == "0"){
            highScoreEvaluation("highScoreFD");
        }else{
            highScoreEvaluation(PlayerPrefs.GetString("currentRoom"));
        }
        
        if(scoreScriptFD.playerScore == 69){
            niceText.SetActive(true);
            Destroy(niceText, 8f);
        }          
    }

    void highScoreEvaluation(string highScoreString)
    {
        if(scoreScriptFD.playerScore > PlayerPrefs.GetInt(highScoreString))
        {
            PlayerPrefs.SetInt(highScoreString, scoreScriptFD.playerScore);
            playerLeaderboardScript.savePlayerScoreRankings();
        }

        highScoreText.text = "Score\n" + scoreScriptFD.playerScore + "\nHigh Score\n" + PlayerPrefs.GetInt(highScoreString);
    }

    public void startGameButton()
    {
        // adsBanner.destroyBanner();
        startButtonScene.SetActive(false);
        gameStart = true;
    }
}
