using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public GameObject objForDrop;
    protected virtual void DropObject(Vector3 posForDrop)
    {
        if (objForDrop != null)
        {
            objForDrop.transform.position = posForDrop;
            objForDrop = null;
        }
        else
        {
            Debug.LogWarning("without reference for object for drop");
        }
    }
}
