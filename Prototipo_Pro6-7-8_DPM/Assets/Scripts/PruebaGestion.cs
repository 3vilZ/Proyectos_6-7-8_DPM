﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaGestion : MonoBehaviour
{
    public Transform tHandPosition;
    public Transform tCamera;
    public bool bItemEquipped = false;
    public GameObject goItemEquipped = null;
    public GameObject goItemInteracted = null;

    float fDetectionRange = 5;

    void Start()
    {
        
    }

    
    void Update()
    {
        ItemDetection();

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
                    CatchItem();
                }
                else if (hit.collider.gameObject.GetComponent<Interactable>().bInteractable)
                {
                    goItemInteracted = hit.collider.gameObject;
                    InteractItem();
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
}