using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tofollow;
    public GameObject FOLLOWER;
    public float Xoffset = 0;
    
    void Start()
    {
        InvokeRepeating("followone", 0, 1);
    }

    // Update is called once per frame
    private void followone()
    {
        FOLLOWER.transform.position = new Vector2(tofollow.position.x, FOLLOWER.transform.position.y);
    }
}
