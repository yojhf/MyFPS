using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MyFPS
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject optionUI;
        [SerializeField] private GameObject creditUI;

        [SerializeField] private string playScene = "PlayScene";
        
        public AudioMixer audioMixer;

        public Slider bgmSlider, sfxSlider;


        // Start is called before the first frame update
        void Start()
        {
            SoundManager.Instance.PlayBgm("MenuBgm");
            LoadOption();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void NewGame()
        {
            SoundManager.Instance.Play("BtnSound");
            SceneFade.instance.FadeOut(playScene);
        }
        public void LoadGame()
        {
            SoundManager.Instance.Play("BtnSound");
            Debug.Log("LoadGame");
        }
        public void Options()
        {
            SoundManager.Instance.Play("BtnSound");
            LoadOption();
            optionUI.SetActive(true);
            menuUI.SetActive(false);
        }
        public void Credits()
        {
            SoundManager.Instance.Play("BtnSound");
            creditUI.SetActive(true);
            menuUI.SetActive(false);

            Debug.Log("Credits");
        }


        public void QuitGame()
        {
            SoundManager.Instance.Play("BtnSound");
            SceneFade.instance.FadeOut(null);

            Invoke("Quit", 1f);
        }

        public void Exit(GameObject targetUI)
        {
            SoundManager.Instance.Play("BtnSound");
            targetUI.SetActive(false);
            menuUI.SetActive(true);
            SaveOption();
        }

        void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif
        }



        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BGMParam", value);
        }
        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SFXParam", value);
        }


        private void SaveOption()
        {
            PlayerPrefs.SetFloat("BGMParam", bgmSlider.value);
            PlayerPrefs.SetFloat("SFXParam", sfxSlider.value);
        }
        void LoadOption()
        {

            bgmSlider.value = PlayerPrefs.GetFloat("BGMParam", 0);
            SetBgmVolume(bgmSlider.value);

            sfxSlider.value = PlayerPrefs.GetFloat("SFXParam", 0);
            SetSfxVolume(sfxSlider.value);
        }
    }
}