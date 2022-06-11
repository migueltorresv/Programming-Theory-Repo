using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : Person
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;

    [SerializeField] private Transform handPos;
    private float horizontal;
    private float vertical;
    
    
    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * vertical * moveSpeed *Time.deltaTime);
        transform.Rotate(Vector3.up * horizontal *turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Container Zone") && base.objForDrop != null)
        {
            Vector3 parent = other.gameObject.transform.parent.transform.position + new Vector3(0, 2, 0);
            base.objForDrop.transform.SetParent(other.transform);
<<<<<<< Updated upstream
            ChangeComponentsValues(false);
            base.DropObject(parent);
=======
<<<<<<< HEAD

            ChangeComponentsValues(false);
            base.DropObject(parent);

            base.objForDrop.GetComponent<Rigidbody>().isKinematic = false;
            DropObject(parent);

=======
            base.objForDrop.GetComponent<Rigidbody>().isKinematic = false;
            DropObject(parent);
>>>>>>> parent of 2612313 (Revert "Merge branch 'scene-main'")
>>>>>>> Stashed changes
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trash") && base.objForDrop == null)
        {
            PickUp(other.gameObject);
        }
    }

    private void PickUp(GameObject other)
    {
        base.objForDrop = other;
        base.objForDrop.transform.SetParent(handPos);
        base.objForDrop.transform.position = handPos.position;
        base.objForDrop.GetComponent<Rigidbody>().isKinematic = true;
    }
}
