using System;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        private static AudioSource _audioSource;

        [SerializeField] private AudioPlaylistSo audioPlayList;

        private void Awake()
        {
            _instance = this;
        }

        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateInstance();
                }
                return _instance;
            }
        }

        private static AudioManager CreateInstance()
        {
            var go = new GameObject("Audio Manager");
            var monoBeh = go.AddComponent<AudioManager>();
            _audioSource = monoBeh.GetComponent<AudioSource>();
            return monoBeh;
        }

        public void PlaySFX(SFX sfxClip)
        {
            AudioClip oneShotClip = null;
            switch (sfxClip)
            {
                case SFX.DeathSfx:
                    oneShotClip = audioPlayList.DeathSfx;
                    break;
                case SFX.KeyPickupSfx:
                    oneShotClip = audioPlayList.KeyPickupSfx;
                    break;
                case SFX.DoorOpen:
                    oneShotClip = audioPlayList.DoorOpenSfx;
                    break;
                case SFX.GravitationChangeSfx:
                    oneShotClip = audioPlayList.GravitationChangeSfx;
                    break;
                case SFX.JumpSfx:
                    oneShotClip = audioPlayList.JumpSfx;
                    break;
            }
            _audioSource.PlayOneShot(oneShotClip);
        }
    }
    
    public enum SFX
    {
        DoorOpen,
        KeyPickupSfx,
        GravitationChangeSfx,
        DeathSfx,
        JumpSfx
    }
}
