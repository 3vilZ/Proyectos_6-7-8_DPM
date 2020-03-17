using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBajo : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //GetComponentInParent<Interactable>().
            }
        }
    }
}
