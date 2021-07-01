using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativePosition : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Start()
    {
        transform.position = player.position + offset;
    }

    
    
}
