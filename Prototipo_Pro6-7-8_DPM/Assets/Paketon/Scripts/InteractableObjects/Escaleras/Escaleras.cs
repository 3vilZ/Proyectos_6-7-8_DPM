using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : Interactable
{
    public bool bClimbing = false;
    public Transform tPuntoInicio;
    public Transform tPuntofinal;

    public SphereCollider goTrigger;

    private void Start()
    {
        goTrigger.enabled = false;
    }

    public void OnStairs()
    {
        if(bClimbing)
        {
            goTrigger.enabled = false;
            bClimbing = false;
        }
        else
        {
            goTrigger.enabled = true;
            bClimbing = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = tPuntofinal.position;
            other.GetComponent<PruebaPersonaje>().bEscaleras = false;
            other.GetComponent<PruebaGestion>().bInteracting = false;
            OnStairs();
        }
    }
}
