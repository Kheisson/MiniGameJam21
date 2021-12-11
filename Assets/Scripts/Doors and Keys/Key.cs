using System;
using UnityEngine;

namespace Doors_and_Keys
{
    public class Key : MonoBehaviour
    {
        private bool wasUsed = false;
        private Animator animator;
        public event Action OnKeyUsed;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !wasUsed)
            {
                UseKey();
            }
        }

        private void UseKey()
        {
            wasUsed = true;
            OnKeyUsed?.Invoke();
            animator.SetTrigger("used");
        }

        private void DestroyKey() // Used by animation event.
        {
            Destroy(gameObject);
        }
    }
}

