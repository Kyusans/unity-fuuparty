using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxygenScript : MonoBehaviour
{
    [SerializeField] gameManagerSI gameManagerSI;
    public void playerDie(){
        gameManagerSI.gameOver();
    }
}
