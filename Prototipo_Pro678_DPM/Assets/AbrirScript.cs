using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirScript : MonoBehaviour
{

    [HideInInspector]public GameObject Pomo;
    [SerializeField] GameObject Mano;
    [SerializeField]GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {

        if (Pomo != null){
            if(Vector3.Distance(Hand.transform.position, Pomo.transform.position) < 0.025f){
                Mano.GetComponent<Animator>().ResetTrigger("UnGrab");
                Mano.GetComponent<Animator>().SetTrigger("Grab");

                if (Input.GetMouseButtonDown(0)){
                    Mano.GetComponent<Animator>().SetTrigger("ActivateHandle");
                    Pomo.GetComponentInParent<Animator>().SetTrigger("ActivateHandle");
                    Mano.GetComponent<Animator>().ResetTrigger("UnGrab");

                    Pomo.transform.parent.transform.parent.transform.parent.GetComponent<Animator>().SetTrigger("Abrir");
                    Mano.GetComponent<Animator>().SetTrigger("Release");
                    Pomo.GetComponentInParent<Animator>().SetTrigger("Release");
                }

            }


            if(Vector3.Distance(Hand.transform.position, Pomo.transform.position) > 0.05f){
                Mano.GetComponent<Animator>().ResetTrigger("Grab");
                Mano.GetComponent<Animator>().SetTrigger("UnGrab");
                
            }
        }
       

    }



    
}


