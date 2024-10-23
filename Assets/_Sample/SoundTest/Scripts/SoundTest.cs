using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class SoundTest : MonoBehaviour
    {
        public AudioClip m_AudioClip;
        public float volume = 1.0f;
        public float pitch = 1.0f;
        public bool loop = false;
        public bool playOnAwake = false;

        AudioSource m_AudioSource;

        // Start is called before the first frame update
        void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();

            SoundOnShot();
            //SoundPlay();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SoundPlay()
        {
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.volume = volume;
            m_AudioSource.pitch = pitch;
            m_AudioSource.loop = loop;
            m_AudioSource.playOnAwake = playOnAwake;


            m_AudioSource.Play();
        }

        void SoundOnShot()
        {
            m_AudioSource.PlayOneShot(m_AudioClip);
        }
    }
}