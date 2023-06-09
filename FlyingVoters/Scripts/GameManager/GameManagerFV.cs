using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerFV : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas, whiteImage, spawner, startButtonCanvas;
    [SerializeField] Text playerScoreEvalutionText, finalScoreText;
    [SerializeField] Animator popUpBox;
    [SerializeField] MainScore mainScore;
    [SerializeField] PlayerJumps playerJumps;
    [SerializeField] PlayerLeaderboardScript playerLeaderboardScript;
    // [SerializeField] AdsBanner adsBanner;
    public bool gameStart;
    public Text totalScoreText;
    int currentScore, obstaclePassed, totalScore, randomNumForString;
    public void gameOver()
    {
        mainScore.evaluateScore();
        playerJumps.playerCollider.GetComponent<Collider2D>().enabled = false;
        gameOverCanvas.SetActive(true);
        Destroy(whiteImage, 1.7f);

        currentScore = PlayerPrefs.GetInt("currentScoreFV");     
        totalScore = currentScore + obstaclePassed;
        
        if(PlayerPrefs.GetString("currentRoom") == "0")
        {
            highScoreEvaluation("playerHighScoreFV");
        }
        else
        {
            highScoreEvaluation(PlayerPrefs.GetString("currentRoom"));
        }
        
        mainScore.secondsCount = 0;
    }

    
    public void startGame(){
        // adsBanner.destroyBanner();
        spawner.SetActive(true);
        startButtonCanvas.SetActive(false);
        gameStart = true;
        playerJumps.playerCollider.GetComponent<Collider2D>().enabled = true;
        playerJumps.rb.bodyType = RigidbodyType2D.Dynamic;
    }
    
    void popUpFalse()
    {
        popUpBox.SetBool("popBoxOpen", false);
    }

    void highScoreEvaluation(string highScoreString)
    {
        if(totalScore > PlayerPrefs.GetFloat(highScoreString))
        {
            totalScoreText.text = totalScore.ToString();
            PlayerPrefs.SetFloat(highScoreString, ((int)totalScore));
            playerScoreEvalutionText.text = "New Highscore!";
            playerLeaderboardScript.savePlayerScoreRankings();
            
        }
        else if(totalScore == 69)
        {
            playerScoreEvalutionText.text = "Nice.";
        }
        else if(totalScore <= 20)
        {
            randomNumForString = Random.Range(1, 4);  
            switch(randomNumForString)
            {
                case 1:
                    playerScoreEvalutionText.text = "Okay...";
                    break;
                case 2:
                    playerScoreEvalutionText.text = "Try again";
                    break;
                case 3:
                    playerScoreEvalutionText.text = "Try harder";
                    break;
                case 4:
                    playerScoreEvalutionText.text = "Welp, you tried right?";
                    break;
            }
        }
        else if(totalScore >= 90)
        {
            randomNumForString = Random.Range(1, 7);
            switch(randomNumForString)
            {
                case 1:
                    playerScoreEvalutionText.text = "Nice game mate!";
                    break;
                case 2:
                    playerScoreEvalutionText.text = "Good game mate!";
                    break;
                case 3:
                    playerScoreEvalutionText.text = "Pretty good mate!";
                    break;
                case 4:
                    playerScoreEvalutionText.text = "Keep it up!";
                    break;
                case 5:
                    playerScoreEvalutionText.text = "Well done!";
                    break;
                case 6:
                    playerScoreEvalutionText.text = "A respectable effort!";
                    break;
            }
        }
        else if(totalScore >= 200)
        {
            randomNumForString = Random.Range(1, 4);
            switch(randomNumForString)
            {
                case 1:
                    playerScoreEvalutionText.text = "Woah!!";
                    break;
                case 2:
                    playerScoreEvalutionText.text = "Wow!!";
                    break;
                case 3:
                    playerScoreEvalutionText.text = "That's a BIG score!";
                    break;
                case 4:
                    playerScoreEvalutionText.text = "Decent score!";
                    break;
                case 5:
                    playerScoreEvalutionText.text = "Respectable score!";
                    break;
                case 6:
                    playerScoreEvalutionText.text = "Big score mate!";
                    break;
            }
        }
        else
        {
            randomNumForString = Random.Range(1, 7);

            switch(randomNumForString)
            {
                case 1:
                    playerScoreEvalutionText.text = "Nice try";
                    break;
                case 2:
                    playerScoreEvalutionText.text = "Good try";
                    break;
                case 3:
                    playerScoreEvalutionText.text = "Fair try";
                    break;
                case 4:
                    playerScoreEvalutionText.text = "Good attempt";
                    break;
                case 5:
                    playerScoreEvalutionText.text = "B+ for effort";
                    break;
                case 6:
                    playerScoreEvalutionText.text = "A- for effort";
                    break;
            }
        }
        
        finalScoreText.text = "Score\n" + totalScore + "\nHigh Score\n" + PlayerPrefs.GetFloat(highScoreString);   
    }

}
