using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace MyFPS
{
    public class SceneFade : MonoBehaviour
    {
        public static SceneFade instance;   

        [SerializeField] private Image fadeImage;
        public AnimationCurve fadeCurve;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            fadeImage.color = new Color(0f, 0f, 0f, 255f);

            if(fadeImage.gameObject.activeSelf == false)
            {
                fadeImage.gameObject.SetActive(true);
                FadeIn(null);
            }

        }

        public void FadeIn(string name)
        {
            StartCoroutine(FadeIn_Co(name));
        }

        public void FadeOut(string name)
        {
            StartCoroutine(FadeOut_Co(name));
        }

        IEnumerator FadeIn_Co(string name)
        {
            float time = 1f;
            float ctime = 0f;

            while (ctime < time)
            {
                float a = fadeCurve.Evaluate(time);

                fadeImage.color = new Color(0f, 0f, 0f, a);
                time -= Time.deltaTime;
                yield return null;
            }

            if (name != null)
            {
                SceneManager.LoadScene(name);
            }

        }

        IEnumerator FadeOut_Co(string name)
        {
            float time = 1f;
            float ctime = 0f;

            while (ctime < time)
            {
                float a = fadeCurve.Evaluate(ctime);

                fadeImage.color = new Color(0f, 0f, 0f, a);
                ctime += Time.deltaTime;
                yield return null;
            }

            if (name != null)
            {
                SceneManager.LoadScene(name);
            }

        }


    }
}