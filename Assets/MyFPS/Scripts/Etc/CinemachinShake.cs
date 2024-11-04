using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MyFPS
{
    public class CinemachinShake : Singleton<CinemachinShake>
    {
        //[SerializeField] private float amplitued = 1f; // 흔들림의 크기
        //[SerializeField] private float frequency = 1f; // 흔들림의 속도

        private bool isShake = false;

        CinemachineVirtualCamera virtualCamera;
        CinemachineBasicMultiChannelPerlin channelsPerlin;

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void Init()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            channelsPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void PlayerHitEffect(float amplitued, float frequency, float time)
        {
            if (isShake == true)
            {
                return;
            }

            StartCoroutine(PlayerHit(amplitued, frequency, time));
        }

        IEnumerator PlayerHit(float amplitued, float frequency, float time)
        {
            isShake = true;

            channelsPerlin.m_AmplitudeGain = amplitued;
            channelsPerlin.m_FrequencyGain = frequency;

            yield return new WaitForSeconds(time);

            channelsPerlin.m_AmplitudeGain = 0f;
            channelsPerlin.m_FrequencyGain = 0f;
            isShake = false;
        }
    }
}