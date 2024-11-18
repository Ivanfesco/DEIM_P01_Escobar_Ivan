using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    [SerializeField] string scenetoload;
    bool doOnce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("Player"))
        {
            if (!doOnce)
            {
                doOnce = true;
                GestionEscenas.SceneManager.LoadScene(scenetoload);
            }
        }
    }


   
}
