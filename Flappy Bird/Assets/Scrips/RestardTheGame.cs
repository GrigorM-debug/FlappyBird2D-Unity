using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestardTheGame : MonoBehaviour
{
    [SerializeField] private AudioClip interactionSound;

    private void OnMouseDown()
    {
        SoundFXManager.instance.PlaySoundFXClip(interactionSound, transform, 1f);
        SceneManager.LoadScene("FlappyBird.HomeScreen");
    }
}
