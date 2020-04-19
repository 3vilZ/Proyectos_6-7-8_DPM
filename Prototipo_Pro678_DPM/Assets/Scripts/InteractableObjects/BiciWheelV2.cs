using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiciWheelV2 : MonoBehaviour
{
   
    GameObject meshFront;
    GameObject meshRear;

    float rbVelocityMagnitude;
    float medRPM;
    



    private float fHorizontalInput;
    private float fVerticalInput;
    private float fSteeringAngle;

    public WheelCollider colFrontW;
    public WheelCollider colBackW;
    public Transform tFrontW;
    public Transform tBackW;
    public float maxSteerAngle = 30;
    public float motorForce = 200;

    Rigidbody cmpRigidbody;


    void Awake()
    {
        cmpRigidbody = GetComponent<Rigidbody>();
        
        //cmpRigidbody.mass = 400;
        cmpRigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
        cmpRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        
        GameObject centerOfmassOBJ = new GameObject("centerOfmass");
        centerOfmassOBJ.transform.parent = transform;
        centerOfmassOBJ.transform.localPosition = new Vector3(0.0f, 0.3f, 0.0f);
        cmpRigidbody.centerOfMass = transform.InverseTransformPoint(centerOfmassOBJ.transform.position);
        /*
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = new Vector3(0.5f, 1.0f, 3.0f);
        */
    }

    void OnEnable()
    {
        WheelCollider WheelColliders = GetComponentInChildren<WheelCollider>();
        WheelColliders.ConfigureVehicleSubsteps(1000, 30, 30);
    }

    void FixedUpdate()
    {
        fHorizontalInput = Input.GetAxis("Horizontal");
        fVerticalInput = Input.GetAxis("Vertical");
        medRPM = (colFrontW.rpm + colBackW.rpm) / 2;
        rbVelocityMagnitude = cmpRigidbody.velocity.magnitude;

        //motorTorque
        if (medRPM > 0)
        {
            colBackW.motorTorque = fVerticalInput * cmpRigidbody.mass * 4.0f;
        }
        else
        {
            colBackW.motorTorque = fVerticalInput * cmpRigidbody.mass * 1.5f;
        }

        //steerAngle
        float nextAngle = fHorizontalInput * 35.0f;
        colFrontW.steerAngle = Mathf.Lerp(colFrontW.steerAngle, nextAngle, 0.125f);

        
        if (Mathf.Abs(colBackW.rpm) > 10000)
        {
            colBackW.motorTorque = 0.0f;
            colBackW.brakeTorque = cmpRigidbody.mass * 5;
        }
        //
        if (rbVelocityMagnitude < 1.0f && Mathf.Abs(fVerticalInput) < 0.1f)
        {
            colBackW.brakeTorque = colFrontW.brakeTorque = cmpRigidbody.mass * 2.0f;
        }
        else
        {
            colBackW.brakeTorque = colFrontW.brakeTorque = 0.0f;
        }
        
        //
        Stabilizer();
    }

    void Update()
    {
        /*
        Vector3 temporaryVector;
        Quaternion temporaryQuaternion;
        //
        colFrontW.GetWorldPose(out temporaryVector, out temporaryQuaternion);
        meshFront.transform.position = temporaryVector;
        meshFront.transform.rotation = temporaryQuaternion;
        //
        colBackW.GetWorldPose(out temporaryVector, out temporaryQuaternion);
        meshRear.transform.position = temporaryVector;
        meshRear.transform.rotation = temporaryQuaternion;
        */
        UpdateWheelPoses();
    }

    public void UpdateWheelPoses()
    {
        UpdateWheelPose(colFrontW, tFrontW);
        //UpdateWheelPose(colBackWLeft, tBackWLeft);
        //UpdateWheelPose(colBackWRight, tBackWRight);
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
        
        Vector3 axisFromRotate = Vector3.Cross(transform.up, Vector3.up);
        Vector3 torqueForce = axisFromRotate.normalized * axisFromRotate.magnitude * 50;
        torqueForce.x = torqueForce.x * 0.4f;
        torqueForce -= cmpRigidbody.angularVelocity;
        cmpRigidbody.AddTorque(torqueForce * cmpRigidbody.mass * 0.02f, ForceMode.Impulse);

        float rpmSign = Mathf.Sign(medRPM) * 0.02f;
        if (rbVelocityMagnitude > 1.0f && colFrontW.isGrounded && colBackW.isGrounded)
        {
            cmpRigidbody.angularVelocity += new Vector3(0, fHorizontalInput * rpmSign, 0);
        }
        
    }
}

