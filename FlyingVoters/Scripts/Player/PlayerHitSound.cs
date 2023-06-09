using UnityEngine;

public class PlayerHitSound : MonoBehaviour
{
    void Start()
    {
        SoundManager.playSound("bonk");
    }
}

