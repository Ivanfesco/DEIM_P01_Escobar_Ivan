using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [Tooltip("Referencia al icono de la llave")]
    [SerializeField] private GameObject keyuiIcon;

    public bool holdingkey = false;


    private void Update()
    {

        if (holdingkey)
        {
            keyuiIcon.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        else
        {
            keyuiIcon.GetComponent<Image>().color = new Color(255, 255, 255, 0.3f);
        }

    }



}
