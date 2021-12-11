using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;

        [SerializeField] private AudioPlaylistSo audioPlayList;

        public static AudioManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            audioPlayList = Resources.Load<AudioPlaylistSo>("Playlist2");
            DontDestroyOnLoad(this);
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
            GetComponent<AudioSource>().PlayOneShot(oneShotClip);
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
