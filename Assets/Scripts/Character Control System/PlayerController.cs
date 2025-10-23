using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public PlayerStats _playerStats;
    [SerializeField] private TrailRenderer _tr;
    private SpriteRenderer _spriteRenderer;



    public Animator animator;
    public Rigidbody2D _rb;

    public bool canDash = true;
    public bool isDashing;



    private Vector2 _moveDirection;

    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference dash;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Jump()
    {
        if (jump.action.WasPressedThisFrame() && _playerStats.isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x,_playerStats.jumpForce);
            _playerStats.isGrounded = false;
            animator.SetBool("IsGrounded", false);
            animator.SetTrigger("Jump");
        }
    }

    void Move()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        animator.SetBool("IsWalking", _moveDirection.x != 0);
        if (_moveDirection.x == 0)
        {
            if(_rb.linearVelocity.x != 0 && _rb.linearVelocity.y == 0)
            {
                _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
            }
            return;
        }
        _rb.linearVelocity = new Vector2(_moveDirection.x * _playerStats.moveSpeed, _rb.linearVelocity.y);

        if (_moveDirection.x < 0)
            _spriteRenderer.flipX = true;
        else if (_moveDirection.x > 0)
            _spriteRenderer.flipX = false;
    }
    
    void PlayerDash()
    {
        if (dash.action.WasPressedThisFrame() && canDash)
        {
            StartCoroutine(Dash());
        }

    }
    private IEnumerator Dash()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        animator.SetTrigger("Dash");
        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.linearVelocity = new Vector2(_moveDirection.x * _playerStats.dashingPower, 0f);
        _tr.emitting = true;
        yield return new WaitForSeconds(_playerStats.dashingTime);
        _tr.emitting = false;
        _rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(_playerStats.dashingCooldown);
        canDash = true;
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        Move();
        Jump();
        PlayerDash();

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _playerStats.isGrounded = true;
            animator.SetBool("IsGrounded", true);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _playerStats.isGrounded = false;
            animator.SetBool("IsGrounded", false);

        }
    }

}
