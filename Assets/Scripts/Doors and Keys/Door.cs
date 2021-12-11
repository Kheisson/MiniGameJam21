using Audio;
using DoorsAndKeys;
using UnityEngine;

namespace Doors_and_Keys
{
    public class Door : MonoBehaviour
    {
        private BoxCollider2D collider;
        private Animator anim;
        private int numberOfKeysLeft = 0;

        private void Awake()
        {
            collider = GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();
        }

        private void Open()
        {
            anim.SetBool("isOpen", true);
            AudioManager.Instance.PlaySFX(SFX.DoorOpen);
        }


        private void OnEnable()
        {
            var keys = FindObjectsOfType<Key>();
            foreach (var key in keys)
            {
                key.OnKeyUsed += UpdateKeyCount;
                numberOfKeysLeft++;
            }
        }

        public void DisableCollider() // called by animation event
        {
            collider.enabled = false;
        }

        void UpdateKeyCount()
        {
            numberOfKeysLeft--;
            if (numberOfKeysLeft == 0)
            {
                Open();
            }
        }
    }
}