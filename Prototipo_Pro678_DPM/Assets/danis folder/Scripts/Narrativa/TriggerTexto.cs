using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexto : MonoBehaviour
{
    public int numberTrigger;
    public bool bIntTextIncomming;
    GestionTextos gt;

    private void Start()
    {
        gt = FindObjectOfType<GestionTextos>().GetComponent<GestionTextos>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bici")
        {
            //Martiiiin
            if(bIntTextIncomming)
            {
                gt.bWillSelect = true;
            }

            if (numberTrigger == 1)
            {
                gt.bTrigger1 = true;
            }
            if (numberTrigger == 2)
            {
                gt.bTrigger2 = true;
            }
            if (numberTrigger == 3)
            {
                gt.bTrigger3 = true;
            }
            if (numberTrigger == 4)
            {
                gt.bTrigger4 = true;
            }
            if (numberTrigger == 5)
            {
                gt.bTrigger5 = true;
            }
            if (numberTrigger == 6)
            {
                gt.bTrigger6 = true;
            }
            if (numberTrigger == 7)
            {
                gt.bTrigger7 = true;
            }
            if (numberTrigger == 8)
            {
                gt.bTrigger8 = true;
            }
            if (numberTrigger == 9)
            {
                gt.bTrigger9 = true;
            }
            if (numberTrigger == 10)
            {
                gt.bTrigger10 = true;
            }
            if (numberTrigger == 11)
            {
                gt.bTrigger11 = true;
            }
            if (numberTrigger == 12)
            {
                gt.bTrigger12 = true;
            }
            if (numberTrigger == 13)
            {
                gt.bTrigger13 = true;
            }
            if (numberTrigger == 14)
            {
                gt.bTrigger14 = true;
            }
            if (numberTrigger == 15)
            {
                gt.bTrigger15 = true;
            }

            Destroy(gameObject);
        }
    }
}
