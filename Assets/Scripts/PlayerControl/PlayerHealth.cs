using UnityEngine;

namespace PlayerControl
{
    public class PlayerHealth : MonoBehaviour
    {
        private bool isDead = false;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (isDead)
            {
                return;
            }

            if (other.collider.CompareTag("Hazards"))
            {
                Die();
            }
        }

        private void Die()
        {
            isDead = false;
            GetComponentInParent<PlayerInput>().Death();
        }
    }
}
