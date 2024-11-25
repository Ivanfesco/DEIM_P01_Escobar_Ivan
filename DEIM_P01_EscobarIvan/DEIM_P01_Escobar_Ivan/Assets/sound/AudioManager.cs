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
    [SerializeField] private AudioSource damageSource;
    [SerializeField] private AudioSource bulletShotSource;
    [SerializeField] private AudioSource jumpSource;

    [SerializeField] private AudioSource EnemySource;
    [SerializeField] private AudioClip EnemyBlockHit;
    [SerializeField] private AudioClip EnemyDamage;

    [SerializeField] private AudioSource IntObjSource;
    [SerializeField] private AudioClip BlockBreak;
    [SerializeField] private AudioClip Spring;

    [SerializeField] private AudioSource reloadsource;

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
            instance.StepSource.pitch = Random.Range(0.85f, 1.15f);
            instance.StepSource.Play();
        }
    }

    public static void playDamage()
    {
        if (!instance.damageSource.isPlaying)
        {
            instance.damageSource.pitch = Random.Range(0.95f, 1.05f);
            instance.damageSource.Play();
        }
    }

    public static void playBulletShot()
    {
        instance.bulletShotSource.pitch = Random.Range(0.85f, 1.15f);
        instance.bulletShotSource.Play();

    }

    public static void playObjectSound(string soundtoplay)
    {
        instance.objectsAudioSource.pitch = Random.Range(0.95f, 1.05f);
        switch (soundtoplay)
        {
            case "coin":
                instance.objectsAudioSource.clip = instance.Coin;
                break;
            case "item":
                instance.objectsAudioSource.clip = instance.Item;
                break;
            default:
                break;
        }

        instance.objectsAudioSource.Play();
    }

    public static void playIntObjSound(string soundtoplay)
    {
        instance.IntObjSource.pitch = Random.Range(0.95f, 1.05f);
        switch(soundtoplay)
        {
            case "block":
                instance.IntObjSource.clip = instance.BlockBreak;
                break;
            case "spring":
                instance.IntObjSource.clip = instance.Spring;
                break;
            default:
                break;
        }
        instance.IntObjSource.Play();


    }


    public static void playReload()
    {
        
            instance.reloadsource.pitch = Random.Range(0.95f, 1.05f);
            instance.reloadsource.Play();
       
    }

    public static void playEnemySound(string soundtoplay)
    {
        instance.EnemySource.pitch = Random.Range(0.95f, 1.05f);

        switch(soundtoplay)
        {

            case "damage":
                instance.EnemySource.clip = instance.EnemyDamage;
                break;

            case "blockhit":
                instance.EnemySource.clip = instance.EnemyBlockHit;
                break;
            default:
                break;

        }
        instance.EnemySource.Play();

    }

    public static void playJumpSound()
    {
        instance.jumpSource.pitch = Random.Range(0.85f, 1.15f);
        instance.jumpSource.Play();

    }
}
