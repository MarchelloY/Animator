using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 3.0F;
    public float jumpForce = 15.0F;
    public float radius = 3.0F;
    
    private Animator _animator;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sprite;

    private CharState State
    {
        set => _animator.SetInteger("State", (int) value);
    }

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (CheckGround())
            State = CharState.Idle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (CheckGround() && Input.GetButtonDown("Jump"))
            Jump();
        if (!CheckGround() && Input.GetButton("Horizontal"))
            State = CharState.Jump;
        if (Input.GetKey(KeyCode.C))
        {
            State = CharState.Crunch;
            //if (Input.GetButton("Horizontal"))
            //    State = CharState.CrunchRun;
        }
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");
        var position = transform.position;
        position = Vector3.MoveTowards(position, position + direction, speed * Time.deltaTime);
        transform.position = position;
        _sprite.flipX = direction.x < 0.0F;
        State = CharState.Run;
    }

    private void Jump()
    {
        _rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        State = CharState.Jump;
    }

    private bool CheckGround()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        return colliders.Length > 1;
    }

    private enum CharState
    {
        Idle,
        Run,
        Jump,
        Crunch,
        //CrunchRun
    }
}