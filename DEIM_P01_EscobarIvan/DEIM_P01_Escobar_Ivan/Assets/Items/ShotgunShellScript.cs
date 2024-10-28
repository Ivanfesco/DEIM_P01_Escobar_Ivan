using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShellScript : MonoBehaviour
{
    private PlayerController pc;
    // Start is called before the first frame update
    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
    }

    public void addShotgunShell()
    {

        pc.amountOfBulletsToSpawn = pc.amountOfBulletsToSpawn + 1;

    }
}
