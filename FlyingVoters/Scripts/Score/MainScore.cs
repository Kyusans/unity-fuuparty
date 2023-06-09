using UnityEngine;
using UnityEngine.UI;

public class MainScore : MonoBehaviour
{
    [SerializeField] PlayerJumps player;
    [SerializeField] Text scoreText, addScoreText;
    [SerializeField] GameManagerFV gameManagerFV;
    [SerializeField] RandomBackgroundFV randomBackgroundFV;
    [SerializeField] Animator scoreAnimator;
    public float secondsCount;
     void Start()
    {
        switch(randomBackgroundFV.randomNumber){
            case 1:
                scoreText.color = Color.white;
                addScoreText.color = Color.white;
                break;
            case 2:
                scoreText.color = Color.white;
                addScoreText.color = Color.white;
                break;
            case 8:
                scoreText.color = Color.white;
                addScoreText.color = Color.white;
                break;
            case 9:
                scoreText.color = Color.white;
                addScoreText.color = Color.white;
                break;
            case 10:
                scoreText.color = Color.white;
                addScoreText.color = Color.white;
                break;
            case 11:
                scoreText.color = Color.white;
                addScoreText.color = Color.white;
                break;
            default:
                scoreText.color = Color.black;
                addScoreText.color = Color.black;
                break;
        }
    }
     void Update(){
         if(player.isAlive && gameManagerFV.gameStart){
             timerUI();
         }
     }
     public void timerUI(){
         secondsCount += Time.deltaTime;
         scoreText.text = ((int)secondsCount).ToString("0"); 
     }

     public void evaluateScore(){  
         scoreAnimator.SetBool("scoreBool", true);
         PlayerPrefs.SetInt("currentScoreFV", ((int)secondsCount));
     }
}
