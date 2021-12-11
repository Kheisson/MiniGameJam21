using PlayerControl;
using UnityEngine;

namespace Animations
{
    public class PlayerAnimation : Animated
    {
        private readonly int _run = Animator.StringToHash("Run");
        private readonly int _isGrounded = Animator.StringToHash("isGrounded");
        private readonly int _verticalVelocity = Animator.StringToHash("verticalVelocity");

        private Rigidbody2D _rb;
        private PlayerInput _playerInput;


        public PlayerAnimation(Animator anim, Rigidbody2D rb) : base(anim)
        {
            _rb = rb;
            _playerInput = anim.GetComponent<PlayerInput>();
        }

        public void Run(bool isRunning)
        {
            _anim.SetBool(_run, isRunning);
        }

        public void HandleJump()
        {
            JumpAnimation();
        }
        public void HandleFalling()
        {
            _anim.SetFloat(_verticalVelocity, _rb.velocity.y);
            _anim.SetBool(_isGrounded, _playerInput.isGrounded);
        }
    }
}