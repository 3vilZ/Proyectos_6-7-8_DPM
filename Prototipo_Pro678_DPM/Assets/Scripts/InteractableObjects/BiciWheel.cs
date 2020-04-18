using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiciWheel : Interactable
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider colFrontW;
    public WheelCollider colBackW;
    public Transform tFrontW;
    public Transform tBackW;
    public float maxSteerAngle = 30;
    public float motorForce = 200;

    Rigidbody cmpRigidbody;
    public GameObject goStabilize;

    //Gestion
    public GameObject goInsideItem1;
    public GameObject goInsideItem2;
    public Transform tLocationPoint1;
    public Transform tLocationPoint2;
    public Transform tPlayerSaddle;
    public Transform tPlayerDown;
    public bool bOnBicicle = false;

    public Collider[] colInteract;

    void Start()
    {
        cmpRigidbody = GetComponent<Rigidbody>();

        GameObject centerOfmassOBJ = new GameObject("centerOfmass");
        centerOfmassOBJ.transform.parent = transform;
        centerOfmassOBJ.transform.localPosition = new Vector3(0f, -0.3f, 0f);
        cmpRigidbody.centerOfMass = transform.InverseTransformPoint(centerOfmassOBJ.transform.position);
    }


    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }
    public void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        colFrontW.steerAngle = m_steeringAngle;
    }
    public void Accelerate()
    {
        colBackW.motorTorque = m_verticalInput * motorForce * cmpRigidbody.mass * Time.deltaTime;
    }
    public void UpdateWheelPoses()
    {
        UpdateWheelPose(colFrontW, tFrontW);
        UpdateWheelPose(colBackW, tBackW);
    }
    public void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = transform.position;
        Quaternion _quat = transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    void Stabilizer()
    {
        /*
        Vector3 axisFromRotate = Vector3.Cross(transform.up, Vector3.up);
        Vector3 torqueForce = axisFromRotate.normalized * axisFromRotate.magnitude * 50;
        //torqueForce.x = torqueForce.x * 0.4f;
        //torqueForce -= cmpRigidbody.angularVelocity;
        torqueForce.x = 0;
        torqueForce.y = 0;
        cmpRigidbody.AddTorque(torqueForce * cmpRigidbody.mass * 0.02f, ForceMode.Impulse);
        

        if (Vector3.Angle(Vector3.up, transform.up) < 30)
        {
            cmpRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0), Time.deltaTime * 5);

        }
        else
        {
            cmpRigidbody.constraints = RigidbodyConstraints.None;
        }

        if (Vector3.Angle(Vector3.up, transform.up) < 30)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0), Time.deltaTime  * 5);
        }

        if (Vector3.Angle(Vector3.up, transform.up) > 10)
        {
            if (transform.rotation.z > 0)
            {
                print("derecha");
            }
            else if (transform.rotation.z < 0)
            {
                print("izquierda");
            }
        }

        */

        if (Vector3.Angle(Vector3.up, transform.up) > 20)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0), Time.deltaTime * 2);
        }


    }

    private void FixedUpdate()
    {

        if (bOnBicicle)
        {
            for (int i = 0; i < colInteract.Length; i++)
            {
                colInteract[i].enabled = false;
            }
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
            Stabilizer();
        }
        else
        {
            for (int i = 0; i < colInteract.Length; i++)
            {
                colInteract[i].enabled = true;
            }
            Steer();
            Accelerate();
            UpdateWheelPoses();
            Stabilizer();
        }
        
    }
}
