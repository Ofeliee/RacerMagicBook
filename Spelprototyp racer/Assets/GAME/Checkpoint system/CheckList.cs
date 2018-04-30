using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckList : MonoBehaviour {

    public int nrOfCheckpoints = 0;
    public int currentCheckpoint = 0;
    public int currentLap;
    public Vector3 startPos;
    public int lap;
    private GameObject[] arr;
    public List<GameObject> checkpoints = new List<GameObject>();

    // Use this for initialization
    void Start () 
	{

        // Player start position
        startPos = transform.position;
        currentCheckpoint = 0;
        currentLap = 0;

        // Find all checkpoint gameobjects, placed in arr and then over to List.
        arr = GameObject.FindGameObjectsWithTag("Checkpoint");
        nrOfCheckpoints = arr.Length;
        print(nrOfCheckpoints);

        for (int i = 0; i < nrOfCheckpoints; i++)
        {
            checkpoints.Add(arr[i]);
        }

        for (int i = 0; i < nrOfCheckpoints; i++)
        {
            if(0 == checkpoints[i].GetComponent<Index>().index)
            {
				GameObject tmp;
				tmp = checkpoints [i];
				checkpoints.RemoveAt(i);
                checkpoints.Insert(tmp.GetComponent<Index>().index, tmp);
            }
        }

		listCorrect (checkpoints);

		for (int i = 0; i < nrOfCheckpoints; i++)
		{
			Debug.Log (checkpoints [i]);
		}
    }
	
	// Update is called once per frame
	void Update () {

        //lap = currentLap;
	}

	private void listCorrect(List<GameObject> checkList)
	{
		float shortestLine = 500000f;
		float tmpVal = 5000f;
		int nextCheckpoint = 554;

		for (int i = 0; i < nrOfCheckpoints; i++)
		{
			shortestLine = 500000f;
			for (int j = i+1; j < nrOfCheckpoints; j++) 
			{
				tmpVal = Vector3.Distance (checkList [i].transform.position, checkList [j].transform.position);

				if (tmpVal < shortestLine) 
				{
					shortestLine = tmpVal;
					nextCheckpoint = j;
				}

				if (j == nrOfCheckpoints - 1)
				{
					GameObject tmp;
					tmp = checkList [nextCheckpoint];
					checkList.RemoveAt (nextCheckpoint);
					checkList.Insert(i+1,tmp);
					checkList [i+1].GetComponent<Index> ().index = (i+1);
				}
			}
		}
	}
}
