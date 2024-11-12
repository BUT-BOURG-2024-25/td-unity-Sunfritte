using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlWithJoystick : MonoBehaviour
{
    public Joystick joystick;
    
    public float speed = 5f;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        
        rb.MovePosition(rb.position + direction * (speed * Time.deltaTime));
    }
}
