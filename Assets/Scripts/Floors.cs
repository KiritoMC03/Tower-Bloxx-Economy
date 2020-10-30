using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floors : MonoBehaviour
{
    private Transform _hookEnd;

    void Start()
    {
        _hookEnd = GameObject.FindGameObjectWithTag("HookEnd").transform;
    }

    void Update()
    {
        
    }

    public void GoToHookEnd()
    {
        transform.position = _hookEnd.position;
    }
}
