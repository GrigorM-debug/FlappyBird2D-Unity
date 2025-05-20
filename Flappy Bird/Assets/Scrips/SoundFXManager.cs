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
            Debug.LogWarning("SoundFXManager: Missing AudioClip, audioSourceObj, or spawnTransform.");
            return;
        }

        audioSourceObj = Instantiate(audioSourceObj, spawnTransform.position, Quaternion.identity);

        if (audioSourceObj == null)
        {
            Debug.LogError("AudioSource component missing from prefab!");
            Destroy(audioSourceObj);
            return;
        }


        audioSourceObj.clip = audioClip;
        audioSourceObj.volume = volume;
        audioSourceObj.Play();
        float clipLenghth = audioClip.length;
        Destroy(audioSourceObj.gameObject, clipLenghth);
    }
}
