using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Neighbour : Person
{
    [SerializeField] private GameObject handPos;
    [SerializeField] private Transform posForDrop;
    [SerializeField] private int count = 0;
    private Animator animator;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(Spawn());
    }

    public void EventAnimationDropObject()
    {
        
        DropObject(posForDrop.position);
    }

    public void EventAnimationInstaceObj()
    {
        InstanceObj();
    }

    private void InstanceObj()
    {
        GameObject obj = Instantiate(objForDrop, handPos.transform.position + new Vector3(-1,0,0), Quaternion.identity);
        objForDrop = obj;
        ChangeComponentsValues();
    }
    
    private IEnumerator Spawn()
    {
        if (count < 5)
        {
            int random = Random.Range(4, 8);
            yield return new WaitForSeconds(random);
            animator.SetTrigger("go to drop");
            count += 1;
            StartCoroutine(Spawn());
        }
        else
        {
            StopCoroutine(Spawn());
            gameManager.CantFinishSpawn += 1;
        }
    }

    protected override void DropObject(Vector3 posForDrop)
    {
        if (objForDrop != null)
        {
            objForDrop.transform.position = posForDrop;
        }
        else
        {
            Debug.LogWarning("without reference for object for drop");
        }
    }
    
    private void ChangeComponentsValues()
    {
        objForDrop.GetComponent<Rigidbody>().isKinematic = false;
        objForDrop.GetComponent<BoxCollider>().enabled = true;
    }
}
