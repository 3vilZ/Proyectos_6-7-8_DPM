using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveSimple : Interactable
{
    public bool bUsed = false;
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
