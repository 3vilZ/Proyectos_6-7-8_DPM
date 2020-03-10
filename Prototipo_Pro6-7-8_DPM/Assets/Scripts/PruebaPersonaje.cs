using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPersonaje : MonoBehaviour
{
    CharacterController cmpCC;

    public float fSpeed = 10;
    public float fGravity = -9.8f;
    float fGroundPull = -2;

    public Transform tGroundCheck;
    public float fGroundRadius;
    public LayerMask groundMask;

    Vector3 v3Velocity;
    bool bIsGrounded;

    private void Awake()
    {
        cmpCC = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        bIsGrounded = Physics.CheckSphere(tGroundCheck.position, fGroundRadius, groundMask);

        if (bIsGrounded && v3Velocity.y < 0)
        {
            v3Velocity.y = fGroundPull;
        }

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xInput + transform.forward * zInput;

        cmpCC.Move(movement * fSpeed * Time.deltaTime);

        v3Velocity.y += fGravity * Time.deltaTime;

        cmpCC.Move(v3Velocity * Time.deltaTime);
    }
}
