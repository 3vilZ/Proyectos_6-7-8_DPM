using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiciWheel : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider colFrontW;
    //public WheelCollider colBackWLeft, colBackWRight;
    public WheelCollider colBackW;
    public Transform tFrontW;
    //public Transform tBackWLeft, tBackWRight;
    public Transform tBackW;
    public float maxSteerAngle = 30;
    public float motorForce = 200;
    public float zRotControl = 10;
    public GameObject goParent;

    void Start()
    {
        
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
        //colBackWLeft.motorTorque = m_verticalInput * motorForce;
        //colBackWRight.motorTorque = m_verticalInput * motorForce;
        colBackW.motorTorque = m_verticalInput * motorForce;
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
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w), Time.deltaTime * zRotControl);
        //goParent.transform.position = transform.position;
    }
}
