using System;
using Animations;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerInput : MonoBehaviour
    {
        private const string HORIZONAL_INPUT_NAME = "Horizontal";
        private const KeyCode JUMP_INPUT_NAME = KeyCode.Space;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private SpriteRenderer playerSprite;

        [Header("Player Speed")] [SerializeField]
        private float playerSpeed = 1f;

        private PlayerAnimation _pa;
        private float _jumpForce = 500f;
        private float _moveFeel = 0.5f;

        private void Start()
        {
            _pa = new PlayerAnimation(playerAnimator);
        }

        private void FixedUpdate()
        {
            Move(Input.GetAxisRaw(HORIZONAL_INPUT_NAME));
        }

        private void Update()
        {
            if (Input.GetKeyDown(JUMP_INPUT_NAME))
                Jump();
        }

        private void Move(float input)
        {
            rb.velocity += Vector2.right * input * playerSpeed;
            if (rb.velocity.x > _moveFeel || rb.velocity.x < -_moveFeel)
            {
                _pa.Run(true);
            }
            else
            {
                _pa.Run(false);
            }

            if (input < 0f)
            {
                playerSprite.flipX = true;
            }
            else if (input > 0.1f)
            {
                playerSprite.flipX = false;
            }
        }

        private void Jump()
        {
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
            _pa.JumpAnimation();
        }
    }

}