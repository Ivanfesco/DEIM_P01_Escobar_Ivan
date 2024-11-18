using GestionEscenas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransitionScript : MonoBehaviour
{
    
    public void isDonefadein()
    {
        SceneManager.IsdoneFadingIn();
    }

    public void isDonefadeout()
    {
        SceneManager.IsDoneFadingOut();
    }
}
