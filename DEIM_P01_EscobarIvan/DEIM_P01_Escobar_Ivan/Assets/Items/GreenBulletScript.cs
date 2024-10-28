using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    private PlayerController pc;

    // Start is called before the first frame update

    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
    }

    public void addGreenBullet()
    {

        pc.hasBulletPenetration = true;

    }
}
