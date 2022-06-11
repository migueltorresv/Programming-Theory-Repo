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
        if (other.gameObject.CompareTag("Trash"))
        {
            Material matContainer = gameObject.transform.parent.transform.GetChild(0)
                .GetComponent<MeshRenderer>().material;
            Material matTrash = other.gameObject.GetComponent<MeshRenderer>().material;

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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
