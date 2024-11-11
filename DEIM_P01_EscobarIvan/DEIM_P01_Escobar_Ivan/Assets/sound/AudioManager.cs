using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource StepSource;
    [SerializeField] private AudioSource objectsAudioSource;
    [SerializeField] private AudioClip Coin;
    [SerializeField] private AudioClip Item;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }
    }

    public static void playFootStep()
    {
        if (!instance.StepSource.isPlaying)
        {
            instance.StepSource.pitch = Random.Range(0.95f, 1.05f);
            instance.StepSource.Play();
        }
    }

    public static void playCoinSound()
    {
        instance.objectsAudioSource.clip = instance.Coin;
        instance.objectsAudioSource.Play();
    }

    public static void playItemSound()
    {
        instance.objectsAudioSource.clip = instance.Item;
        instance.objectsAudioSource.Play();
    }
}
