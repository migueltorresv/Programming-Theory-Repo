using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            Material matContainer = gameObject.transform.parent.transform.GetChild(0)
                .GetComponent<MeshRenderer>().material;
            Material matTrash = other.gameObject.GetComponent<MeshRenderer>().material;

            if (matContainer.name == matTrash.name)
            {
                //add point player
                Debug.Log("Correcto");
            }
            else
            {
                //reject or make animation or change color
                Debug.Log("Incorrecto");
            }
        }
    }
}
