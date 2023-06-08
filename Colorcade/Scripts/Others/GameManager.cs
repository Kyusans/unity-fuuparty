using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScene, nextColorUI;
    [SerializeField] Text playerScoreText, playerHighScoreText, mainPlayerScoreText;
    [SerializeField] Animator playerScoreAnimator, fuuAnimator;
    [SerializeField] PlayerLeaderboardScript playerLeaderboardScript;
    int playerScore;

    void Update()
    {
        mainPlayerScoreText.text = playerScore.ToString();
    }
    public void gameOver()
    {
        nextColorUI.SetActive(false);
        playerScoreAnimator.SetBool("gameOver", true);
        gameOverScene.SetActive(true);
        if(PlayerPrefs.GetString("currentRoom") == "0")
        {
            ShowScore("playerHighScoreCC");
        }
        else
        {
            ShowScore(PlayerPrefs.GetString("currentRoom"));
        }
        playerLeaderboardScript.muteBGM();
    }
    public void addScore()
    {
        playerScore++;
    }
    void ShowScore(string playerHighScoreString)
    {
        if(playerScore > PlayerPrefs.GetInt(playerHighScoreString))
        {
            PlayerPrefs.SetInt(playerHighScoreString, playerScore);
            playerLeaderboardScript.savePlayerScoreRankings();
        }
        playerScoreText.text = playerScore.ToString();
        playerHighScoreText.text = PlayerPrefs.GetInt(playerHighScoreString).ToString();

        if(playerScore == 69)
        {
            Invoke("fuuAnimatorTrue", 0.6f);
        }
    } 

    void fuuAnimatorTrue()
    {
        fuuAnimator.enabled = true;
    }

}
