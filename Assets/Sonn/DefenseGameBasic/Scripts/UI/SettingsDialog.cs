using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Sonn.DefenseGameBasic
{
    public class SettingsDialog : Dialog
    {
        public Slider musicSlider, soundSlider;
        public AudioMixer myAudioMixer;

        public override void Show(bool isShow)
        {
            base.Show(isShow);
            if (isShow)
            {
                LoadVolumeSetting();
            }    
        }
        
        public void SetMusicVolume()
        {
            float musicVolume = musicSlider.value;
            myAudioMixer.SetFloat(Const.MUSIC_VOL_PREF, Mathf.Log10(musicVolume) * 20);
            PlayerPrefs.SetFloat(Const.MUSIC_VOLUME, musicVolume);

        }
        public void SetSoundsVolume()
        {
            float soundVolume = soundSlider.value;
            myAudioMixer.SetFloat(Const.SOUND_VOL_PREF, Mathf.Log10(soundVolume) * 20);
            PlayerPrefs.SetFloat(Const.SOUND_VOLUME, soundVolume);

        }    
        private void LoadVolumeSetting()
        {
            musicSlider.value = PlayerPrefs.GetFloat(Const.MUSIC_VOLUME);
            soundSlider.value = PlayerPrefs.GetFloat(Const.SOUND_VOLUME);
        }    
    }

}
