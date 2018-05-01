using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public int cPassed = 0;
    public Vector3 currentPos;
    public Quaternion currentRot;
    public GameObject listHolder;

    private void OnTriggerEnter(Collider other)
    {
        //Get the checkpoint element in the list. and put the the element nr in index
        if (other.CompareTag("Checkpoint"))
        {
			Debug.Log ("CHECK");
			if (cPassed < listHolder.GetComponent<CheckList> ().nrOfCheckpoints) 
			{
			
				if (other.gameObject == listHolder.GetComponent<CheckList> ().checkpoints [cPassed]) 
				{
					// Gets the checkpoints location and increase current checkpoint by 1 
					GetLocation (other);
					cPassed += 1;
					print ("HIT");
				}
			}
        }

    }
    private void GetLocation(Collider checkpoint)
    {
        currentPos = checkpoint.GetComponent<Transform>().position;
        currentRot = checkpoint.GetComponent<Transform>().rotation;
		//Change respawn
		gameObject.GetComponent<O_RespawnScript> ().checkChange (currentPos, currentRot);
    }
}
