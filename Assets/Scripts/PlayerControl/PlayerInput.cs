using Animations;
using Base;
using Gravity;
using LevelLoading;
using UnityEngine;

namespace PlayerControl
{
    public class PlayerInput : Humaniod
    {
        private const string HORIZONAL_INPUT_NAME = "Horizontal";
        private const KeyCode JUMP_INPUT_NAME = KeyCode.Space;

        [Header("Component list")][Space(5)]
        [SerializeField] private Rigidbody2D playerRb;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Transform playersBody;
        [SerializeField] private BoxCollider2D playerCollider;

        [Header("Jump settings")] 
        [SerializeField] private LayerMask collideLayerMask;
        [SerializeField] private Transform playersFeet;
        [SerializeField] private float collideRadius;

        [Header("Configures")] 
        [SerializeField] private float playerSpeed = 3f;
        [SerializeField] private float jumpForce = 500f;
        [SerializeField] private float moveFeel = 0.5f;

        private PlayerAnimation _pa;


        private void Start()
        {
            _pa = new PlayerAnimation(playerAnimator);
            rb = playerRb;
            body = playersBody;
        }

        private void FixedUpdate()
        {
            Move(Input.GetAxisRaw(HORIZONAL_INPUT_NAME));
        }

        private void Update()
        {
            //Handling jumping
            if (Input.GetKeyDown(JUMP_INPUT_NAME) && IsGrounded)
                Jump();
            _pa.HandleFalling(IsGrounded, rb.velocity.y);
            
            //Handling gravitation
            if (Input.GetKeyDown(KeyCode.E))
            {
                GravityControl.Switch();
                //_facingRight = !_facingRight;
            }
        }

        private void Move(float input)
        {
            rb.velocity = new Vector2(input * playerSpeed, rb.velocity.y);

            //Handle running animation
            if (rb.velocity.x > moveFeel || rb.velocity.x < -moveFeel)
                _pa.Run(true);
            else
                _pa.Run(false);

            //Handle Flipping of character
            if (_facingRight == false && rb.velocity.x > 0)
                FlipDirection();
            else if (_facingRight == true && rb.velocity.x < 0)
                FlipDirection();
        }
        

        private void Jump()
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            _pa.HandleJump();
        }

        private bool GroundCheck()
        {
            return Physics2D.OverlapCircle(playersFeet.position, collideRadius, collideLayerMask);;
        }

        private bool IsGrounded => GroundCheck();

        public override void Flip()
        {
            base.Flip();
            jumpForce *= -1;
        }

        public void Death()
        {
            StartCoroutine(SceneLoader.Instance.GameOver());
            FindObjectOfType<Hourglass>().gameObject.SetActive(false);
            _pa.HandleDeath();
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            this.enabled = false;
        }

        private void DestroyPlayer() // called by animation event
        {
            Destroy(gameObject, 1f);
        }
    }
}