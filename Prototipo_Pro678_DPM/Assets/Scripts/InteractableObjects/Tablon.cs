using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablon : Interactable
{
    GameObject[] goChildPlanks;
    

    void Start()
    {
        goChildPlanks = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            goChildPlanks[i] = transform.GetChild(i).gameObject;
            goChildPlanks[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void DestroyPlanks()
    {
        GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            goChildPlanks[i].GetComponent<BoxCollider>().enabled = true;
            goChildPlanks[i].GetComponent<Rigidbody>().isKinematic = false;
            goChildPlanks[i].AddComponent<Interactable>();
            goChildPlanks[i].GetComponent<Interactable>().bCatchable = true;
        }
    }
}
