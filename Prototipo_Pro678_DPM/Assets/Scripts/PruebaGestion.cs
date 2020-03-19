﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaGestion : MonoBehaviour
{
    public Transform tHandPosition;
    public Transform tCamera;
    public bool bItemEquipped = false;
    public bool bInteracting = false;
    public GameObject goItemEquipped = null;
    public GameObject goItemInteracted = null;

    float fDetectionRange = 5;

    PruebaPersonaje pruebaPersonaje;

    void Start()
    {
        pruebaPersonaje = GetComponent<PruebaPersonaje>();
    }

    
    void Update()
    {
        if (bInteracting)
        {
            StopInteract();
        }
        else
        {
            ItemDetection();
        }

        if (bItemEquipped)
        {
            UseItem();
            DropItem();
        }
    }

    public void ItemDetection()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(tCamera.position, tCamera.forward, out hit, fDetectionRange))
            {
                if(hit.collider.gameObject.GetComponent<Interactable>().bCatchable && !bItemEquipped)
                {
                    goItemEquipped = hit.collider.gameObject;

                    if (goItemEquipped.GetComponent<Interactable>().bParented)
                    {
                        goItemEquipped.GetComponent<Interactable>().goRecipiente.gameObject.GetComponent<Cubo>().goInsideItem = null;
                        goItemEquipped.GetComponent<Interactable>().bParented = false;
                    }

                    CatchItem();
                }
                else if (hit.collider.gameObject.GetComponent<Interactable>().bInteractable)
                {
                    goItemInteracted = hit.collider.gameObject;
                    InteractItem();
                }
                else if (!hit.collider.gameObject.GetComponent<Interactable>())
                {
                    if(goItemEquipped != null)
                    {
                        goItemEquipped = null;
                    }
                }
            }
        }
    }
    

    public void CatchItem()
    {
        bItemEquipped = true;
        goItemEquipped.GetComponent<Rigidbody>().useGravity = false;
        goItemEquipped.GetComponent<Rigidbody>().isKinematic = true;
        goItemEquipped.transform.position = tHandPosition.position;
        goItemEquipped.transform.rotation = tHandPosition.rotation;
        goItemEquipped.transform.parent = tHandPosition;
    }

    public void InteractItem()
    {
        //Cubo

        if (goItemInteracted.GetComponent<Cubo>())
        {
            if (goItemEquipped == null)
            {
                goItemEquipped = goItemInteracted;
                CatchItem();
            }
            else
            {
                if (goItemInteracted.GetComponent<Cubo>().goInsideItem == null)
                {
                    goItemInteracted.GetComponent<Cubo>().goInsideItem = goItemEquipped;
                    goItemEquipped.GetComponent<Interactable>().goRecipiente = goItemInteracted;
                    goItemEquipped.GetComponent<Interactable>().bParented = true;
                    goItemEquipped.transform.position = goItemInteracted.GetComponent<Cubo>().tLocationPoint.position;
                    goItemEquipped.transform.rotation = goItemInteracted.GetComponent<Cubo>().tLocationPoint.rotation;
                    goItemEquipped.transform.parent = goItemInteracted.transform;  
                    goItemEquipped = null;
                    bItemEquipped = false;
                }
            }
        }


        //PuertaSimple

        if (goItemInteracted.GetComponent<PuertaSimple>())
        {
            if(!goItemInteracted.GetComponent<PuertaSimple>().bOpen)
            {
                goItemInteracted.GetComponentInParent<Animator>().SetTrigger("Open");
                goItemInteracted.GetComponent<PuertaSimple>().bOpen = true;
            }
            else
            {
                goItemInteracted.GetComponentInParent<Animator>().SetTrigger("Close");
                goItemInteracted.GetComponent<PuertaSimple>().bOpen = false;
            }
        }

        //PuertaLlave

        if (goItemInteracted.GetComponent<PuertaLlave>())
        {
            if (!goItemInteracted.GetComponent<PuertaLlave>().bLocked)
            {
                if (!goItemInteracted.GetComponent<PuertaLlave>().bOpen)
                {
                    goItemInteracted.GetComponentInParent<Animator>().SetTrigger("Open");
                    goItemInteracted.GetComponent<PuertaLlave>().bOpen = true;
                }
                else
                {
                    goItemInteracted.GetComponentInParent<Animator>().SetTrigger("Close");
                    goItemInteracted.GetComponent<PuertaLlave>().bOpen = false;
                }
            }

            if (goItemInteracted.GetComponent<PuertaLlave>().bLocked && goItemEquipped.GetComponent<LlaveSimple>() && goItemEquipped != null)
            {
                goItemInteracted.GetComponent<PuertaLlave>().bLocked = false;
                goItemEquipped.GetComponent<LlaveSimple>().Destroy();
                goItemEquipped = null;
                bItemEquipped = false;

                goItemInteracted.GetComponentInParent<Animator>().SetTrigger("Open");
                goItemInteracted.GetComponent<PuertaLlave>().bOpen = true;
            }

            
        }

        //PlataformaSimple

        if (goItemInteracted.GetComponent<PlataformaSimple>())
        {
            //transform.position = Vector3.MoveTowards(transform.position, goItemInteracted.GetComponent<PlataformaSimple>().tPuntoSubida.position, 1);
            GetComponent<CharacterController>().enabled = false;
            transform.position = goItemInteracted.GetComponent<PlataformaSimple>().tPuntoSubida.position;
            GetComponent<CharacterController>().enabled = true;
        }

        //Escalera
        if (goItemInteracted.GetComponent<Escaleras>())
        {
            bInteracting = true;
            DropItem2();
            GetComponent<CharacterController>().enabled = false;
            transform.position = goItemInteracted.GetComponent<Escaleras>().tPuntoInicio.position;
            GetComponent<CharacterController>().enabled = true;
            goItemInteracted.GetComponent<Escaleras>().OnStairs();
            pruebaPersonaje.bEscaleras = true;
        }
    }

    public void StopInteract()
    {
        //Escalera

        if (goItemInteracted.GetComponent<Escaleras>())
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                pruebaPersonaje.bEscaleras = false;
                goItemInteracted.GetComponent<Escaleras>().OnStairs();
                bInteracting = false;
            }
        }
    }

    public void UseItem()
    {

    }

    public void DropItem()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            goItemEquipped.transform.parent = null;
            goItemEquipped.GetComponent<Rigidbody>().useGravity = true;
            goItemEquipped.GetComponent<Rigidbody>().isKinematic = false;
            goItemEquipped = null;
            bItemEquipped = false;
        }
    }

    public void DropItem2()
    {
        if (goItemEquipped != null)
        {
            goItemEquipped.transform.parent = null;
            goItemEquipped.GetComponent<Rigidbody>().useGravity = true;
            goItemEquipped.GetComponent<Rigidbody>().isKinematic = false;
            goItemEquipped = null;
            bItemEquipped = false;
        }
    }
}
