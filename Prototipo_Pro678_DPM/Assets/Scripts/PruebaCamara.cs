using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaCamara : MonoBehaviour
{
    public float fMouseSpeed = 100;
    public Transform tPlayerBody;

    float fXrot = 0;
    float fYrot = 0;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float xMouse = Input.GetAxis("Mouse X") * fMouseSpeed * Time.deltaTime;
        float yMouse = Input.GetAxis("Mouse Y") * fMouseSpeed * Time.deltaTime;

        fXrot -= yMouse;
        fXrot = Mathf.Clamp(fXrot, -90, 90);

        transform.localRotation = Quaternion.Euler(fXrot, 0, 0);
        tPlayerBody.Rotate(Vector3.up * xMouse);
    }
}
