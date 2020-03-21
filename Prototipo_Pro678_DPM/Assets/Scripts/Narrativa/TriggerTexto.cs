using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexto : MonoBehaviour
{
    public int numberTrigger;
    GestionTextos gt;

    private void Start()
    {
        gt = FindObjectOfType<GestionTextos>().GetComponent<GestionTextos>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Martiiiin
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

            Destroy(gameObject);
        }
    }
}
