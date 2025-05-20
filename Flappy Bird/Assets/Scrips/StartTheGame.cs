using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour
{
    [SerializeField] private AudioClip interactionSound;

    // Update is called once per frame
    private void Update()
    {
        //Keyboard and mouse input
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            PlaySoundAndStartTheGame();
        }

        //Touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                PlaySoundAndStartTheGame();
            }
        }
    }

    private void PlaySoundAndStartTheGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(interactionSound, transform, 1f);
        SceneManager.LoadScene("FlappyBird.GamePlay");
    }
}
