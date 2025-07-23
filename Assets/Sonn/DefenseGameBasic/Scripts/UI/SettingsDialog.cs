using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Sonn.DefenseGameBasic
{
    public class SettingsDialog : Dialog, IComponentChecking
    {
        public Slider musicSlider, soundSlider;
        public AudioMixer myAudioMixer;

        public bool IsComponentsNull()
        {
            return musicSlider == null || soundSlider == null || myAudioMixer == null;
        }

        public override void Show(bool isShow)
        {
            base.Show(isShow);
        }

        private void Start()
        {
            if (IsComponentsNull())
            {
                return;
            }
            LoadVolumeSettings();
        }

        public void SetMusicVolume()
        {
            if (IsComponentsNull())
            {
                return;
            }
            float musicVolume = musicSlider.value;
            myAudioMixer.SetFloat(Const.MUSIC_VOL_PREF, Mathf.Log10(musicVolume) * 20);
            Pref.musicVolume = musicVolume;
            
        }
        public void SetSoundsVolume()
        {
            if (IsComponentsNull())
            {
                return;
            }
            float soundVolume = soundSlider.value;
            myAudioMixer.SetFloat(Const.SOUND_VOL_PREF, Mathf.Log10(soundVolume) * 20);
            Pref.soundVolume = soundVolume; 
        }   

        public void LoadVolumeSettings()
        {
            if (IsComponentsNull())
            {
                return;
            }
            
            float musicVolume = Pref.musicVolume;
            float soundVolume = Pref.soundVolume;
            musicSlider.value = musicVolume;
            soundSlider.value = soundVolume;

            SetMusicVolume();
            SetSoundsVolume();
        }    
    }
}
