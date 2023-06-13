using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManagerSI : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI playerFinalScoreText;
   [SerializeField] Text playerScoreText;
   [SerializeField] GameObject startButtonCanvas, playerBubble, gameOverScene, playerOxygen, playerScoreGameObject;
   [SerializeField] playerScriptSI playerScriptSI;
   [SerializeField] Animator oxygenAnimator, playerAnimator;
   [SerializeField] PlayerLeaderboardScript playerLeaderboardScript;
   
//    [SerializeField] AdsBanner adsBanner;
   float secondsCount;
   public bool startGameSI = false;

   void Update(){
       if(playerScriptSI.isAliveSI && startGameSI){
           secondsCount += Time.deltaTime;
           playerScoreText.text = ((int)secondsCount).ToString("0");
       }
   }
   public void startGameButton(){
    //    adsBanner.destroyBanner();
       startButtonCanvas.SetActive(false);
       startGameSI = true;
       playerAnimator.enabled = false;
       playerBubble.SetActive(false);
       oxygenAnimator.enabled = true;
       playerScriptSI.playerDynamicRB();
   }
   public void gameOver(){
       if(PlayerPrefs.GetString("currentRoom") == "0"){
           highScoreEvaluation("playerHighScoreSwimIn");
       }else{
           highScoreEvaluation(PlayerPrefs.GetString("currentRoom"));
       }

       playerScriptSI.isAliveSI = false;
       oxygenAnimator.speed = 0;
       gameOverScene.SetActive(true);
       playerOxygen.SetActive(false);
       playerScoreGameObject.SetActive(false);
       playerLeaderboardScript.muteBGM();
        
   }

   void highScoreEvaluation(string highScoreString)
    {
        if((int)secondsCount > PlayerPrefs.GetInt(highScoreString))
        {
            PlayerPrefs.SetInt(highScoreString, (int)secondsCount);
            playerLeaderboardScript.savePlayerScoreRankings();
        }

        playerFinalScoreText.text = "Score\n" + (int)secondsCount + "\nHigh Score\n" + PlayerPrefs.GetInt(highScoreString);
        
    } 

      
}
