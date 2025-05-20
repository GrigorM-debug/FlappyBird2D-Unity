using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarButtonClickHandler : MonoBehaviour
{
    [SerializeField] private AudioClip interactionSound;

    private void OnMouseDown()
    {
        SoundFXManager.instance.PlaySoundFXClip(interactionSound, transform, 1f);
        SceneManager.LoadScene("FlappyBird.GetReady");
    }
}
