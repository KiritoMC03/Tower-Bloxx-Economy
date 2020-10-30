using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    internal static bool CheckKeyDown(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal static void SetIsTrigger(GameObject gameObject, bool boolean)
    {
        if(gameObject.GetComponent<Collider>() != null)
        {
            gameObject.GetComponent<Collider>().isTrigger = boolean;
        }
        else if (gameObject.GetComponent<Collider2D>() != null)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = boolean;
        }
    }
}