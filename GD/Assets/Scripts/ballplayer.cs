using UnityEngine;


public class ballplayer : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField] private float maxSpeed = 4;
    public float jumps = 0;
    public float extrajumps = 0;
    float gravity = 0;
    float extra = 1;

    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private bool doJump = false;
    private bool doExtraJump = false;

    void Update()
    {
        doJump |= Input.GetKeyDown(jumpKeyCode) || Input.GetButtonDown("Jump");
        doExtraJump |= Input.GetKeyDown(jumpKeyCode) || Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        Vector2 motion = rigidbody2D.velocity;

        // Движение по вертикали
        if (doJump)
        {
            doJump = false;
            if (jumps >= 1)
            {
                gravity = rigidbody2D.gravityScale;
                rigidbody2D.gravityScale = -gravity;
                jumpForce = -jumpForce;
            }

        }
        if (doExtraJump)
        {
            doExtraJump = false;
            if (extrajumps >= 1)
            {
                motion.y = jumpForce / extra;
                extrajumps = extrajumps - 1;
            }

        }
        //--

        // Движение по горизонтали
        var input = Input.GetAxis("Horizontal");
        motion.x = 1 * maxSpeed;
        //--
        rigidbody2D.velocity = motion;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<ground>(out var ground))
        {
            jumps = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("jumper"))
        {
            extrajumps = 1;
            extra = 2;
        }
        if (collision.CompareTag("bigjumper"))
        {
            extrajumps = 1;
            extra = 1;
        }
    }



    public void exitJumper()
    {
        extrajumps = 0;
    }
    public void reverse()
    {
        gravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = -gravity;
        jumpForce = -jumpForce;
    }
    public void UFO()
    {
        extrajumps = 500;
        jumpForce = 25;
        rigidbody2D.gravityScale = 10;
        maxSpeed = 10;
    }
    public void exitUFO()
    {
        extrajumps = 0;
        jumpForce = 45;
        rigidbody2D.gravityScale = 20;
        maxSpeed = 10;
    }
    public void HorizontalReverse()
    {
        maxSpeed = -maxSpeed;
    }
}
