using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using SceneManagerUnity = UnityEngine.SceneManagement.SceneManager;
namespace GestionEscenas
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager instance;
        BGscript bgs;
        [SerializeField] private Image transitionImage;
        [SerializeField] public bool doneFadeOut;
        [SerializeField] public bool doneFadeIn;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }


        public static void LoadScene(string sceneName)
        {

            instance.StartCoroutine(instance.LoadSceneCoroutine(sceneName));


        }

        public static void IsDoneFadingOut()
        {
            instance.doneFadeOut = true;
        }

        public static void IsdoneFadingIn()
        {
            instance.doneFadeIn = true;
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            doneFadeIn = false;
            doneFadeOut = false;

            instance.transitionImage.GetComponent<Animator>().SetTrigger("FadeOut");


            while (!doneFadeOut)
            {
                yield return null;
            }
            
            AsyncOperation loadAsyncOperation = SceneManagerUnity.LoadSceneAsync(sceneName);

            while (!loadAsyncOperation.isDone)
            {
                yield return null;
            }

            

            instance.transitionImage.GetComponent<Animator>().SetTrigger("FadeIn");


            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "MainMenu")
            {
                if (InventoryScript.instance != null)
                {
                    InventoryScript.instance.CheckForIcons();
                }
                if (HealthManager.instance != null)
                {
                    HealthManager.instance.checkForIcons();
                }
                if (CameraScript.instance != null)
                {
                    CameraScript.instance.findplayer();
                }
            }

            bgs = FindAnyObjectByType<BGscript>();
            if(bgs != null)
            {
                bgs.setbg();
            }
            print("test");
            while (!doneFadeIn)
            {
                yield return null;
            }

            doneFadeIn= false;
            doneFadeOut= false;
            yield break;

        }

    }
}