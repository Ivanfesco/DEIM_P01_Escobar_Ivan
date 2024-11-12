using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemKeeper : MonoBehaviour
{
    PlayerController pc;
    ItemManager manager;
    [SerializeField] public List<string> itemsKept = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pc = FindAnyObjectByType<PlayerController>();
        

    }

    // Update is called once per frame

}
