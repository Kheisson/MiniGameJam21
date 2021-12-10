using UnityEngine;

namespace Animations
{
    public abstract class Animated 
    {
        protected readonly Animator _anim;
        
        private readonly int _jump = Animator.StringToHash("Jump");
        private readonly int _death = Animator.StringToHash("Death");

        protected Animated(Animator anim)
        {
            _anim = anim;
        }

        public void JumpAnimation()
        {
            _anim.SetTrigger(_jump);
        }

        public void DeathAnimation()
        {
            _anim.SetTrigger(_death);
        }
    }
}