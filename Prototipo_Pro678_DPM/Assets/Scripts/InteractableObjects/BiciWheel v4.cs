using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiciWheelv4 : MonoBehaviour

{
    public List<BikeAxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public Transform centerOfMass;
    public Vector3 inertiaTensorVector;
    private float motor;
    private float steering;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = centerOfMass.position;
        rigidbody.inertiaTensorRotation = Quaternion.identity;
        rigidbody.inertiaTensor = inertiaTensorVector * rigidbody.mass;
    }

    void FixedUpdate()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        foreach (BikeAxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.wheelCol.steerAngle = steering;
                axleInfo.wheel.localEulerAngles = new Vector3(0, steering, 0);
            }
            if (axleInfo.motor)
            {
                axleInfo.wheelCol.motorTorque = motor;
            }
            axleInfo.wheel.Rotate(new Vector3(rigidbody.velocity.z, 0, 0));
        }
    }
}

[System.Serializable]
public class BikeAxleInfo
{
    public WheelCollider wheelCol;
    public Transform wheel;
    public bool motor;
    public bool steering;
}