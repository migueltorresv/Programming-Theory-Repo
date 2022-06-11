using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

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
                gameManager.AddGoodPoint();
            }
            else
            {
                //reject or make animation or change color
                gameManager.AddBadPoint();
            }
        }
    }
}
