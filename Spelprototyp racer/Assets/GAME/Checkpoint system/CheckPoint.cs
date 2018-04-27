using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public int index = -1;
    Vector3 currentPos;
    public GameObject reefref;

    private void OnTriggerEnter(Collider other)
    {
        //Get the checkpoint element in the list. and put the the element nr in index
        index += 1; 

        if((index > reefref.GetComponent<CheckList>().currentCheckpoint))
        {
            if(other.CompareTag("Checkpoint"))
            {
                Debug.Log("Hit!");
                // Gets the checkpoints location and increase current checkpoint by 1 
                GetLocation(other);
                reefref.GetComponent<CheckList>().currentCheckpoint += 1; 
            }
        }

    }

    private void GetLocation(Collider player)
    {
        currentPos = transform.position;
    }
}
