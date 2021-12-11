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
            _anim.SetTrigger("death");
            AudioManager.Instance.PlaySFX(SFX.DeathEnemySfx);
        }
    }
}