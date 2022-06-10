using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Trash : MonoBehaviour
{
    [SerializeField] private Material[] materialLocal;
    private void Start()
    {
        int randomIndex = Random.Range(0, materialLocal.Length);
        gameObject.GetComponent<MeshRenderer>().material = materialLocal[randomIndex];
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(4);
    }
}
