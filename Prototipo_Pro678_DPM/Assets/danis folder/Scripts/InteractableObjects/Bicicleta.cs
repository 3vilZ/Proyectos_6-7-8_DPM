using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicicleta : Interactable
{
    //Interactable
    public GameObject goInsideItem1;
    public GameObject goInsideItem2;
    public Transform tLocationPoint1;
    public Transform tLocationPoint2;
    public Transform tPlayerSaddle;
    public Transform tPlayerDown;
    public bool bOnBicicle = false;

    public Collider[] colInteract;

    //Controller
    public float velocidadMov = 10;
    public float velocidadRot = 180;
    public float aceleracionMov = 3;
    public float aceleracionRot = 30;

    public float fGravity = -9.8f;
    float fGroundPull = -2;
    bool bIsGrounded;
    Vector3 v3Velocity;

    public Transform tGroundCheck;
    public float fGroundRadius;
    public LayerMask groundMask;

    Vector3 velocidadMovActual;
    Vector3 velocidadRotActual;

    CharacterController biciCC;


    void Start()
    {
        biciCC = GetComponent<CharacterController>();
        biciCC.enabled = false;
    }

    
    void Update()
    {
        if (bOnBicicle)
        {
            for (int i = 0; i < colInteract.Length; i++)
            {
                colInteract[i].enabled = false;
            }

            biciCC.enabled = true;

            Movimiento();
            Rotacion();
        }
        else
        {
            for (int i = 0; i < colInteract.Length; i++)
            {
                colInteract[i].enabled = true;
            }

            biciCC.enabled = false;
        }
    }

    void Movimiento()
    {
        bIsGrounded = Physics.CheckSphere(tGroundCheck.position, fGroundRadius, groundMask);

        if (bIsGrounded && v3Velocity.y < 0)
        {
            v3Velocity.y = fGroundPull;
        }

        float zInput = Input.GetAxis("Vertical");
        Vector3 velocidadMovDeseada = transform.forward * velocidadMov * zInput;
        velocidadMovActual = Vector3.MoveTowards(velocidadMovActual, velocidadMovDeseada, aceleracionMov * Time.deltaTime);
        //velocidadMovActual = Vector3.Slerp(velocidadMovActual, velocidadMovDeseada, aceleracionMov);

        biciCC.Move(velocidadMovActual * Time.deltaTime);

        v3Velocity.y += fGravity * Time.deltaTime;

        biciCC.Move(v3Velocity * Time.deltaTime);
    }

    void Rotacion()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector3 velocidadRotDeseada = new Vector3(0, velocidadRot * xInput, 0);
        velocidadRotActual = Vector3.MoveTowards(velocidadRotActual, velocidadRotDeseada, aceleracionRot * Time.deltaTime);

        transform.Rotate(0, velocidadRotActual.y * Time.deltaTime, 0);
    }
}
