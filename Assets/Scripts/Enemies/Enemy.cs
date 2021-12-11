using Animations;
using Base;
using UnityEngine;

namespace Enemies
{
    public class Enemy : Humaniod
    {

        [SerializeField] private Rigidbody2D enemyRb;
        [SerializeField] private Transform enemiesFeet;
        [SerializeField] private Transform enemiesBody;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private float enemiesSpeed;
        [SerializeField] private float circleRadius;
        [SerializeField] private bool onPlatform;
        [SerializeField] private Collider2D feetCollider;

        private EnemyAnimation _ea;
        private void Start()
        {
            rb = enemyRb;
            body = enemiesBody;
            _ea = new EnemyAnimation(GetComponent<Animator>());
        }

        private void FixedUpdate()
        {
            enemyRb.velocity = new Vector2(enemiesSpeed, enemyRb.velocity.y);
            if (onPlatform && ReachedEndOfPlatform)
            {
                FlipDirection();
                enemiesSpeed *= -1;
            }
        }

        public override void Flip()
        {
            base.Flip();
            enemiesSpeed *= -1;
            onPlatform = false;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!onPlatform)
            {
                FlipDirection();
                enemiesSpeed *= -1;
            }
            
            if (other.gameObject.CompareTag("Hazards") && other.otherCollider != feetCollider)
            {
                _ea.HandleDeath();
                Destroy(gameObject, 0.1f);
            }
        }

        private bool ReachedEndOfPlatform => !Physics2D.OverlapCircle(enemiesFeet.position, circleRadius, groundLayerMask);
    }
}
