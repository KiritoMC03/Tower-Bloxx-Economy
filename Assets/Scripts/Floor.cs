using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utils;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Floor : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _isHangs = true;
    private int ID;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        ID = GameManager.CurrentFloor + 1;
        GameManager.CurrentFloor += 1;
    }

    void Update()
    {
        if (_isHangs)
        {
            FloorThrower();
        }
    }

    private void FloorThrower()
    {
        if (CheckKeyDown(KeyCode.Space))
        {
            _rigidbody.isKinematic = false;
            _isHangs = false;

            StartCoroutine(IsTreiggerSetter());
        }
    }

    private IEnumerator IsTreiggerSetter()
    {
        yield return new WaitForSeconds(0.2f);
        SetIsTrigger(gameObject, false);

        yield return new WaitForSeconds(0.4f);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 5f;
        StopCoroutine(IsTreiggerSetter());
    }
}
