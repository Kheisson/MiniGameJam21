using UnityEngine;

namespace Animations
{
    public class PlayerAnimation : Animated
    {
        private readonly int _run = Animator.StringToHash("Run");
        public PlayerAnimation(Animator anim) : base(anim)
        {
        }

        public void Run(bool isRunning)
        {
            _anim.SetBool(_run, isRunning);
        }

        public void HandleJump()
        {
            JumpAnimation();
        }
        
    }
}