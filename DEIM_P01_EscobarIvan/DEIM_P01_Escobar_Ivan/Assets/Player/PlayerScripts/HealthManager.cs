using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    [SerializeField] private Sprite[] heartarray;
    [SerializeField] private GameObject hearticon1;
    [SerializeField] private GameObject hearticon2;
    [SerializeField] private GameObject hearticon3;
    [SerializeField] private GameObject gameovercanvas;
    float timer=0;
    float timeElapsed=0;
    bool damageable = true;
    float immunitytime = 1;
    public int health = 3;
    public int maxHealth = 3;
    void Start()
    {

        gameovercanvas.SetActive(false);


    }
    

    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }


        switch(health)
        {

            case 3:
                hearticon1.GetComponent<Image>().sprite = heartarray[1];
                hearticon2.GetComponent<Image>().sprite = heartarray[1];
                hearticon3.GetComponent<Image>().sprite = heartarray[1];
                break;

            case 2:
                hearticon1.GetComponent<Image>().sprite = heartarray[1];
                hearticon2.GetComponent<Image>().sprite = heartarray[1];
                hearticon3.GetComponent<Image>().sprite = heartarray[0];
                break;

            case 1:
                hearticon1.GetComponent<Image>().sprite = heartarray[1];
                hearticon2.GetComponent<Image>().sprite = heartarray[0];
                hearticon3.GetComponent<Image>().sprite = heartarray[0];
                break;

            case < 1:
                hearticon1.GetComponent<Image>().sprite = heartarray[0];
                hearticon2.GetComponent<Image>().sprite = heartarray[0];
                hearticon3.GetComponent<Image>().sprite = heartarray[0];
                gameovercanvas.SetActive(true);
                GetComponentInParent<PlayerController>().inputallowed = false;
                break;



        }

        if (timer <= immunitytime)
        {
            timer = Time.time - timeElapsed;

        }
        if (timer >= immunitytime)
        {
            damageable = true;
        }

    }

    public void PlayerDamage(int damage)

    {
        if (damageable)
        {
            damageable = false;
            health = health - damage;
            timer = 0;
            timeElapsed = Time.time;
        }
    }
}
