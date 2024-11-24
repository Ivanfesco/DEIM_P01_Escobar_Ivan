using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscript : MonoBehaviour
{

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, (cam.transform.position.y + -(cam.transform.position.y / 30)) - 5, 10);
    }
}
