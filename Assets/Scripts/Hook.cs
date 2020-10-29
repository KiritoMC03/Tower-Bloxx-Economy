using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(HingeJoint2D))]
public class Hook : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private HingeJoint2D _hingeJoint;
    private JointAngleLimits2D _angleLimits;
    private JointMotor2D _motor;

    [SerializeField] private float _baseAngleLimits = 10;
    [SerializeField] private float _baseMotorSpeed = 30;
    private float _maxAngleLimit;
    private float _minAngleLimit;

    private float _previousMaxAngle = 0;
    private float _previousMinAngle = 0;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _hingeJoint = GetComponent<HingeJoint2D>();

        _maxAngleLimit = _baseAngleLimits;
        _minAngleLimit = -1 * _baseAngleLimits;

        _hingeJoint.useLimits = true;
        _angleLimits = _hingeJoint.limits;
        _angleLimits.max = _maxAngleLimit;
        _angleLimits.min = _minAngleLimit;
        _hingeJoint.limits = _angleLimits;

        _hingeJoint.useMotor = true;

        //ControlMotor();
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!ChangePreviousAngle())
        {
            ControlMotor();
        }
    }

    private void ControlMotor()
    {
        _motor = _hingeJoint.motor;
        var zRotation = transform.localRotation.z;

        if (zRotation == 0)
        {
            _motor.motorSpeed = _baseMotorSpeed;
        }
        else if (zRotation >= 0)
        {
            _motor.motorSpeed = _baseMotorSpeed;
        }
        else if (zRotation <= 0)
        {
            _motor.motorSpeed = _baseMotorSpeed * -1;
        }

        _hingeJoint.motor = _motor;
    }

    private bool ChangePreviousAngle()
    {
        var zRotation = (float)Math.Round((transform.localRotation.z * 100), 1);

        Debug.Log("zRotation + " + zRotation);

        if (zRotation != _previousMaxAngle)
        {
            _previousMaxAngle = zRotation;
            return true;
        }
        else
        {
            return false;
        }
    }
}
