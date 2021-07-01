using UnityEngine;
using UnityEngine.Events;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField] private float maxSpeed = 4;
    public float jumps = 0;
    public float extrajumps = 0;
    float gravity = 0;
    float extra = 1;
    const float reservegravity = 20;

    private new Rigidbody2D rigidbody2D;
    public UnityEvent OnJump;
    public UnityEvent EnterDash;
    public UnityEvent ExitDash_;
    private Vector2 motion;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
        motion = rigidbody2D.velocity;
    }
        
    

    private bool doJump = true;
    private bool doExtraJump = false;
    private enum Dash {None, Wait, Active}
    private Dash doDash = Dash.None;
    private bool isDashing = false;
    private bool plane = false;
    //private Vector2 motion = rigidbody2D.velocity;

    void Update()
    {
        doJump = Input.GetKey(jumpKeyCode);
        doExtraJump = Input.GetKeyDown(jumpKeyCode) || Input.GetButtonDown("Jump");

        if (doDash == Dash.Wait && Input.GetKeyDown(jumpKeyCode))
        {
            doDash = Dash.Active;
            EnterDash.Invoke();
            rigidbody2D.gravityScale = 0;
            
        }
        if (doDash == Dash.Active && Input.GetKeyUp(jumpKeyCode))
        {
            doDash = Dash.None;
            ExitDash_.Invoke();
            rigidbody2D.gravityScale = reservegravity;

        }


        gravity = rigidbody2D.gravityScale;
        if (Input.GetKeyDown(jumpKeyCode))
        {
            OnJump.Invoke();
        }
        if (Input.GetKeyUp(jumpKeyCode))
        {
            OnJump.Invoke();
        }
    }

    private void FixedUpdate()
    {
        motion = rigidbody2D.velocity;

        // Движение по вертикали
        if (doDash != Dash.Active)
        {

            if (doJump)
            {
                doJump = false;
                if (jumps >= 1)
                {
                    motion.y = jumpForce;
                    //print("jumped");
                    jumps = jumps - 1;
                }

            }
            if (doExtraJump)
            {
                doExtraJump = false;
                if (extrajumps >= 1)
                {
                    motion.y = jumpForce / extra;
                    //print("jumped");
                    extrajumps = extrajumps - 1;
                }

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
            if (plane == false)
            {
                jumps = 1;
            }
            
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
            //print("enter");
        }
        if (collision.CompareTag("dash"))
        {
            doDash = Dash.Wait;
            rigidbody2D.gravityScale = reservegravity;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("jumper"))
        {
            extrajumps = 0;
            //print("exit");
        }
        if (collision.CompareTag("bigjumper"))
        {
            extrajumps = 0;
            //print("exit");
        }
    }




    public void exitJumper()
    {
        extrajumps = 0;
        print("exit");

    }
    public void ExitDash()
    {
        if (doDash == Dash.Wait)
        {
            doDash = Dash.None;
            //ExitDash_.Invoke();
            print("nodash");
        }
        
    }
    
    public void reverse()
    {
        gravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = -gravity;
        jumpForce = -jumpForce;
    }
    public void HorizontalReverse()
    {
        maxSpeed = -maxSpeed;
    }
    public void UFO()
    {
        extrajumps = 5000;
        jumpForce = 45;
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
    public void Plane()
    {
        jumps = 5000;
        jumpForce = 15;
        rigidbody2D.gravityScale = 5;
        plane = true;
        
    }
    public void exitPlane()
    {
        jumps = 0;
        jumpForce = 45;
        rigidbody2D.gravityScale = 20;
        maxSpeed = 10;
        plane = false;
    }
    public void jumppad()
    {


        motion.y = jumpForce * 1.5f;
        rigidbody2D.velocity = motion;


    }
    public void reversejump()
    {
        motion.y = jumpForce*2;
        rigidbody2D.velocity = motion;
        gravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = -gravity;
        jumpForce = -jumpForce;
        motion.y = jumpForce;
        rigidbody2D.velocity = motion;
    }
}
