using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;

    void playGameOver()
    {
        audioSource.enabled = true;
    }
}
