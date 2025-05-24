using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseTheGame : MonoBehaviour
{
    public static CloseTheGame instance;

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

    //Close the game when the sprite is click
    private void OnMouseDown()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
