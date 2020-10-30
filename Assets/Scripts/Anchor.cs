using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void GoUp()
    {
        Debug.Log("Up!");
        var newPos = transform.position;
        newPos.y += 1.21f;

        var curretnPosition = Vector3.Lerp(transform.position, newPos, Time.deltaTime);

        transform.position = newPos;
    }
}
