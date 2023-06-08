using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    [SerializeField] GameObject blackBackground, blueBackground, greenBackground, redBackground, violetBackground;
    public int randomNumber;
    void Awake()
    {       
        randomNumber = Random.Range(1, 6);
        switch(randomNumber){
            case 1:
                blackBackground.SetActive(true);
                break;
            case 2:
                blueBackground.SetActive(true);
                break;
            case 3:
                greenBackground.SetActive(true);
                break;
            case 4:
                redBackground.SetActive(true);
                break;
            case 5:
                violetBackground.SetActive(true);
                break;
        } 
        
    }
}
