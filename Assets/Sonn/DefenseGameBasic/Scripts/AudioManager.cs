using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sonn.DefenseGameBasic
{
    public class AudioManager : MonoBehaviour, IComponentChecking
    {
        public AudioSource musicSource, atkSource, enemyDeadSource, gameOverSource;

        public bool IsComponentsNull()
        {
            return musicSource == null || atkSource == null || enemyDeadSource == null 
                || gameOverSource == null;
        }
        
        public void PlayMusic(AudioSource audioSource)
        {
            if (IsComponentsNull())
            {
                return;
            }

            if (audioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
        public void PauseMusic(AudioSource audioSource)
        {
            if (IsComponentsNull())
            {
                return;
            }

            if (audioSource)
            {
                audioSource.Pause();
            }
        }
        public void ResumeMusic(AudioSource audioSource)
        {
            if (IsComponentsNull())
            {
                return;
            }

            if (audioSource)
            {
                audioSource.UnPause();
            }
        }
        public void PlaySoundOneShots(AudioSource audioSource)
        {
            if (IsComponentsNull())
            {
                return;
            }

            if (audioSource)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        
    }
}
