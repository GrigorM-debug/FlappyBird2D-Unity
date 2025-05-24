using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenMode : MonoBehaviour
{
    public static FullScreenMode instance;

    private bool IsAlreadyInFullScreeen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnMouseDown()
    {   
        if (IsAlreadyInFullScreeen)
        {
            Screen.SetResolution(1280, 720, false);
            IsAlreadyInFullScreeen = false;
        }
        else
        {
            Screen.fullScreen = true;
            IsAlreadyInFullScreeen = true;
        }
    }
}
