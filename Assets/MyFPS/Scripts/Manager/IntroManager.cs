using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MyFPS
{
    public class IntroManager : MonoBehaviour
    {
        [SerializeField] private string loadScene = "PlayScene";
        [SerializeField] private GameObject camera_v;
        [SerializeField] private GameObject introUI;
        [SerializeField] private GameObject windowLight;

        [SerializeField] private float cartSpeed = 0.25f;
        public CinemachineDollyCart dollyCart;
        public GameObject CinemachineTrackedDolly;

        private bool[] isArrive;
        private int index = 0;

        CinemachineSmoothPath cinemachineSmoothPath;
        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = camera_v.GetComponent<Animator>();
            cinemachineSmoothPath = CinemachineTrackedDolly.GetComponent<CinemachineSmoothPath>();

            isArrive = new bool[cinemachineSmoothPath.m_Waypoints.Length];

            SoundManager.Instance.PlayBgm("IntroBgm");
            
            StartCoroutine(StartIntro());

        }

        // Update is called once per frame
        void Update()
        {
            if(dollyCart.m_Position >= index && isArrive[index] == false)
            {
                if(index == isArrive.Length - 1)
                {             
                    // 마지막 연출
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }

            // 인트로 스킵

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SoundManager.Instance.Stop("IntroBgm");
                SceneFade.instance.FadeOut(loadScene);
            }

        }

        IEnumerator StartIntro()
        {
            dollyCart.m_Speed = 0f;

            isArrive[index] = true;
            index++;

            yield return new WaitForSeconds(1f);

            animator.SetTrigger("AroundTrigger");

            yield return new WaitForSeconds(3f);

            dollyCart.m_Speed = cartSpeed;

        }

        IEnumerator StayIntro()
        {
            isArrive[index] = true;
            index++;
            //dollyCart.m_Speed = 0f;

            AroundAnimation();

            yield return new WaitForSeconds(3f);

            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);

            int nowIndex = index - 1;

            switch(nowIndex)
            {
                case 1:
                    introUI.SetActive(true);
                    yield return new WaitForSeconds(3f);
                    break;
                case 2:
                    introUI.SetActive(false);
                    yield return new WaitForSeconds(3f);
                    break;
                case 3:
                    yield return new WaitForSeconds(2f);
                    windowLight.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    break;
            }


            dollyCart.m_Speed = cartSpeed;


            Debug.Log(index);
        }

        IEnumerator EndIntro()
        {
            isArrive[index] = true;

      
            yield return new WaitForSeconds(3f);

            windowLight.SetActive(false);
            SoundManager.Instance.Stop("IntroBgm");
            SceneFade.instance.FadeOut(loadScene);

            Debug.Log("aa");
        }

        void AroundAnimation()
        {
            if(index <= 6)
            {
                if((index % 2) == 0)
                {
                    animator.SetBool("isLeft", true);
                }
                else
                {
                    animator.SetBool("isRight", true);
                }
            }
        }
    }
}