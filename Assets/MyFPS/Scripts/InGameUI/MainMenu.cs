using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string playScene = "PlayScene";

        // Start is called before the first frame update
        void Start()
        {
  
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void NewGame()
        {
            SceneFade.instance.FadeOut(playScene);
        }
        public void LoadGame()
        {
            Debug.Log("LoadGame");
        }
        public void Options()
        {
            Debug.Log("Options");
        }
        public void Credits()
        {
            Debug.Log("Credits");
        }
        public void QuitGame()
        {
            SceneFade.instance.FadeOut(null);

            Invoke("Quit", 1f);
        }
        void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif
        }
    }
}