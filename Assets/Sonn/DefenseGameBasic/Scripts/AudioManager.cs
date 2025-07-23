using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sonn.DefenseGameBasic
{
    public class AudioManager : MonoBehaviour, IComponentChecking
    {
        public AudioSource musicSource, atkSource, enemyDeadSource, gameOverSource;
        public SettingsDialog settings;

        private static AudioManager Instance;
        

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            ApplySavedVolume();
            PlayMusic(musicSource);
        }
        public void ApplySavedVolume()
        {
            if (IsComponentsNull())
            {
                return;
            }

            float musicVolume = PlayerPrefs.HasKey(Const.MUSIC_VOLUME) ? PlayerPrefs.GetFloat(Const.MUSIC_VOLUME) : 1f;
            float soundVolume = PlayerPrefs.HasKey(Const.SOUND_VOLUME) ? PlayerPrefs.GetFloat(Const.SOUND_VOLUME) : 1f;
            
            settings.myAudioMixer.SetFloat(Const.MUSIC_VOL_PREF, Mathf.Log10(musicVolume) * 20);
            settings.myAudioMixer.SetFloat(Const.SOUND_VOL_PREF, Mathf.Log10(soundVolume) * 20);
        }    
        public bool IsComponentsNull()
        {
            return musicSource == null || atkSource == null || enemyDeadSource == null 
                || gameOverSource == null || settings == null;
        }
        public void PlayMusic(AudioSource audioSource)
        {
            if (IsComponentsNull())
            {
                return;
            }
            if (audioSource && audioSource.enabled)
            {
                audioSource.Play();
            }
        }
        public void PauseMusic(AudioSource audioSource)
        {
            if (IsComponentsNull())
            {
                return;
            }
            if (audioSource && audioSource.enabled)
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
            if (audioSource && audioSource.enabled)
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
            if (audioSource && audioSource.enabled)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        
    }
}
