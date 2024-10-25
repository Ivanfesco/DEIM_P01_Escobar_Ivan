using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartScript : MonoBehaviour
{

    [SerializeField] GameObject Arrow;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name.StartsWith("Player"))
        {
            SceneManager.LoadScene("Forest");
        }
    }


   
}
