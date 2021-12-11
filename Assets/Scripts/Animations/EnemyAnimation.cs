using Audio;
using UnityEngine;

namespace Animations
{
    public class EnemyAnimation : Animated
    {
        public EnemyAnimation(Animator anim) : base(anim)
        {
            
        }
        
        public void HandleDeath()
        {
            AudioManager.Instance.PlaySFX(SFX.DeathEnemySfx);
        }
    }
}