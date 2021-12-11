using System;
using UnityEngine;
using UnityEngine.Events;

namespace Turotial
{
    public class TriggerText : MonoBehaviour
    {
        public UnityEvent Trigger;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Trigger?.Invoke();
            Destroy(this);
        }
    }
}
