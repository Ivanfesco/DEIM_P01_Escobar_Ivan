using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGscript : MonoBehaviour
{
    [SerializeField] Sprite[] backgrounds;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
    }


    public void setbg()
    {
        cam = FindAnyObjectByType<Camera>();

        switch(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            case "Forest":
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                gameObject.GetComponent<SpriteRenderer>().sprite = backgrounds[0];
                break;
            case "Tundra":
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);    

                gameObject.GetComponent<SpriteRenderer>().sprite = backgrounds[1];
                break;
            case "Desert":
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                gameObject.GetComponent<SpriteRenderer>().sprite = backgrounds[2];
                break ;
            case "MainMenu":
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, (cam.transform.position.y + -(cam.transform.position.y / 30)) - 5, 10);
    }
}
