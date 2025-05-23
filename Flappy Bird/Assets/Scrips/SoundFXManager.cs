using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField]private AudioSource audioSourceObj;

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

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        Debug.LogWarning($"Audio Clip Name: {audioClip.name}");
        Debug.LogWarning($"Spawn transform: {spawnTransform.name}");

        if (audioClip == null || audioSourceObj == null || spawnTransform == null)
        {
            return;
        }

        AudioSource tempAudioSource = Instantiate(audioSourceObj, spawnTransform.position, Quaternion.identity);
        tempAudioSource.clip = audioClip;
        tempAudioSource.volume = volume;
        tempAudioSource.Play();

        Destroy(tempAudioSource.gameObject, audioClip.length);
    }
}
