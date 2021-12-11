using PlayerControl;
using UnityEngine;

namespace Animations
{
    public class PlayerAnimation : Animated
    {
        private readonly int _run = Animator.StringToHash("Run");
        private readonly int _isGrounded = Animator.StringToHash("isGrounded");
        private readonly int _verticalVelocity = Animator.StringToHash("verticalVelocity");


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
        public void HandleFalling(bool isGrounded, float yVelocity)
        {
            _anim.SetFloat(_verticalVelocity, yVelocity);
            _anim.SetBool(_isGrounded, isGrounded);
        }
    }
}