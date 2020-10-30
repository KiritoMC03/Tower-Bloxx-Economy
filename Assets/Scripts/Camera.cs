using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform _anchor;
    [SerializeField] private float _damping = 1.5f;
    private Vector2 _offset;
    private Vector3 targetPosition;
    private Vector3 curretnPosition;

    void Start()
    {
        FindAnchor();
    }

    void Update()
    {
        Move();
    }

    private void FindAnchor()
    {
        _anchor = GameObject.FindGameObjectWithTag("Anchor").transform;

        _offset = new Vector2(0, _anchor.position.y - transform.position.y);
        transform.position = new Vector3(0, _anchor.position.y - _offset.y, transform.position.z);
    }

    private void Move()
    {
        targetPosition = new Vector3(0, _anchor.position.y - _offset.y, transform.position.z);
        curretnPosition = Vector3.Lerp(transform.position, targetPosition, _damping * Time.deltaTime);

        transform.position = curretnPosition;
    }
}
