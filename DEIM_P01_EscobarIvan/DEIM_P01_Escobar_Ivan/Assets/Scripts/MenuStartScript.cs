using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartScript : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name.StartsWith("Player"))
        {
            GestionEscenas.SceneManager.LoadScene("Forest");
        }
    }


   
}
