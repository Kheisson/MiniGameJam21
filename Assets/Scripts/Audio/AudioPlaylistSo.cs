using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "Audio/Create Playlist", fileName = "New Playlist")]
    public class AudioPlaylistSo : ScriptableObject
    {
        [SerializeField] private AudioClip jumpSFX;
        [SerializeField] private AudioClip deathSFX;
        [SerializeField] private AudioClip gravitationChangeSFX;
        [SerializeField] private AudioClip keyPickupSFX;
        [SerializeField] private AudioClip doorOpenSFX;
        
        public AudioClip DoorOpenSfx => doorOpenSFX;
        public AudioClip KeyPickupSfx => keyPickupSFX;
        public AudioClip GravitationChangeSfx => gravitationChangeSFX;
        public AudioClip DeathSfx => deathSFX;
        public AudioClip JumpSfx => jumpSFX;
    }
}
