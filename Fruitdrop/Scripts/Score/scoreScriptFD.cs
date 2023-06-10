using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreScriptFD : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int playerScore = 0;

    void Update()
    {
        scoreText.text = playerScore.ToString();
    }

    public void addScore(){
        playerScore++;
    }
}
