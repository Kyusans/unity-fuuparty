using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrientationLandscape : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
