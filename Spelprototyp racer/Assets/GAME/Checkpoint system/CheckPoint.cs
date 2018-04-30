using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public int cPassed = 0;
    Vector3 currentPos;
    Quaternion currentRot;
    public GameObject reefref;

    private void OnTriggerEnter(Collider other)
    {
        //Get the checkpoint element in the list. and put the the element nr in index
        if (other.CompareTag("CheckPoint"))
        {
                if (other.gameObject.GetComponent<Index>().index == cPassed)
                {
                    // Gets the checkpoints location and increase current checkpoint by 1 
                    GetLocation(other);
                    cPassed += 1;
                    print("HIT");
                }
        }

    }
    private void GetLocation(Collider checkpoint)
    {
        currentPos = checkpoint.GetComponent<Transform>().position;
        currentRot = checkpoint.GetComponent<Transform>().rotation;
    }
}
