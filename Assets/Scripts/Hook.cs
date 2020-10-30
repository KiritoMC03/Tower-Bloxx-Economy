using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(HingeJoint2D))]
public class Hook : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private HingeJoint2D _hingeJoint;
    private JointAngleLimits2D _angleLimits;

    [SerializeField] private float _baseAngleLimits = 10;
    private float _finalAngleLimits;
    private float _maxAngleLimit;
    private float _minAngleLimit;

    private const float SWING_FORCE_MULT = 20f;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _hingeJoint = GetComponent<HingeJoint2D>();

        _hingeJoint.useLimits = true;
        CalcAngleLimits();

        _rigidbody.AddRelativeForce(new Vector2(_finalAngleLimits * SWING_FORCE_MULT, 0));
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    private void CalcAngleLimits()
    {
        _hingeJoint.useLimits = true;

        _finalAngleLimits = _baseAngleLimits * Difficult;

        _maxAngleLimit = _finalAngleLimits;
        _minAngleLimit = -1 * _finalAngleLimits;

        _angleLimits = _hingeJoint.limits;
        _angleLimits.max = _maxAngleLimit;
        _angleLimits.min = _minAngleLimit;
        _hingeJoint.limits = _angleLimits;
    }
}
