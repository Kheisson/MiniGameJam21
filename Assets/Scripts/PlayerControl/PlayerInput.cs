using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HORIZONAL_INPUT_NAME = "Horizontal";
    private const KeyCode JUMP_INPUT_NAME = KeyCode.Space;

    [SerializeField]
    private Rigidbody2D rb;

    private float _playerSpeed = 1f;

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
        rb.velocity += Vector2.right * input * _playerSpeed;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * 1000f, ForceMode2D.Force);
    }
}
