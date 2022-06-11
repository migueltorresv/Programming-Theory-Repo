using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    [SerializeField] private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

>>>>>>> Stashed changes
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash") )
        {
            CheckParentComponents(other.gameObject, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            CheckParentComponents(other.gameObject, false);
        }
    }

    private void CheckParentComponents(GameObject other, bool isEnter)
    {
        GameObject parent = gameObject.transform.parent.gameObject;
            
        Material containerMat = parent.transform.GetChild(0)
            .GetComponent<MeshRenderer>().material;
        Material otherMat = other.GetComponent<MeshRenderer>().material;

<<<<<<< Updated upstream
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
=======
        if (containerMat.name == otherMat.name)
        {
            //add point player
            if (isEnter)
                gameManager.GoodPoint += 1;
            else
                gameManager.GoodPoint -= 1;
        }
        else
        {
            //reject or make animation or change color
            if (isEnter)
                gameManager.BadPoint += 1;
            else
                gameManager.BadPoint -= 1;
>>>>>>> Stashed changes
        }
    }
}
