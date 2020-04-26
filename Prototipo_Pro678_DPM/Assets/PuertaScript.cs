using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaScript : MonoBehaviour
{

    [SerializeField]GameObject TargetGrab;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Player"){
            other.transform.Find("Controlador").GetComponent<Animator>().SetTrigger("SalidaMano");

            print(other.transform.GetComponentInChildren<FastIKFabric>().name);
            other.transform.GetComponentInChildren<FastIKFabric>().Target = TargetGrab.transform;
            other.GetComponent<AbrirScript>().Pomo = TargetGrab.gameObject;

        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.name == "Player"){
        other.transform.Find("Controlador").GetComponent<Animator>().SetTrigger("EntradaMano");

        other.transform.GetComponentInChildren<FastIKFabric>().Target = null;
        other.GetComponent<AbrirScript>().Pomo = null;
        }
    }

}
