using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPersonaje : MonoBehaviour
{
    CharacterController cmpCC;
    Animator cmpAnim;

    float fSpeed;
    public float fWalk = 10;
    public float fRun = 20;
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
        cmpAnim = GetComponent<Animator>();
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

        print(movement);

        cmpCC.Move(movement * fSpeed * Time.deltaTime);

        v3Velocity.y += fGravity * Time.deltaTime;

        cmpCC.Move(v3Velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            fSpeed = fRun;
        }
        else
        {           
            fSpeed = fWalk;
        }

        if (movement.x != 0 && movement.z != 0)
        {
            if (fSpeed == fRun)
            {
                cmpAnim.SetBool("Running", true);
                cmpAnim.SetBool("Walking", false);
            }
            else
            {
                cmpAnim.SetBool("Walking", true);
                cmpAnim.SetBool("Running", false);
            }
        }
        else
        {
            cmpAnim.SetBool("Running", false);
            cmpAnim.SetBool("Walking", false);
        }
    }
}
