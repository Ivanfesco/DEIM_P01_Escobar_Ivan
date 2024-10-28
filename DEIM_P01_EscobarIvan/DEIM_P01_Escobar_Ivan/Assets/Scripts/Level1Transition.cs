using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Transition : MonoBehaviour
{




    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name.StartsWith("Player"))
        {
            SceneManager.LoadScene("Tundra");
        }
    }


   
}
