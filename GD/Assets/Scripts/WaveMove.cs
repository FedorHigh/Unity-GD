using UnityEngine;


public class WaveMove : MonoBehaviour
{
    [SerializeField]
    float power = 1, time = 1;
    Rigidbody2D rbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeDirection", 0, time);
    }
    void ChangeDirection()
    {
        rbody2D.velocity = new Vector2(
            rbody2D.velocity.x,
            power
        );
        power = -power;
    }
    public void TurnOff()
    {
        enabled = false;
        CancelInvoke();
    }
}