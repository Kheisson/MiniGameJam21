using Audio;
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
            AudioManager.Instance.PlaySFX(SFX.JumpSfx);
        }
        public void HandleFalling(bool isGrounded, float yVelocity)
        {
            _anim.SetFloat(_verticalVelocity, yVelocity);
            _anim.SetBool(_isGrounded, isGrounded);
        }

        public void HandleDeath()
        {
            _anim.SetTrigger("Death");
            AudioManager.Instance.PlaySFX(SFX.DeathSfx);
        }
    }
}