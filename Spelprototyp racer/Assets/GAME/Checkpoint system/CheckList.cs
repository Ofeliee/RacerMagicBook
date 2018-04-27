using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckList : MonoBehaviour {

    int nrOfCheckpoints = 0;
    public int currentCheckpoint = 0;
    public int currentLap;
    public Vector3 startPos;
    public int lap;
    private GameObject[] arr;
    public List<GameObject> checkpoints = new List<GameObject>();

    // Use this for initialization
    void Start () {

        // Player start position
        startPos = transform.position;
        currentCheckpoint = 0;
        currentLap = 0;

        // Find all checkpoint gameobjects, placed in arr and then over to List.
        arr = GameObject.FindGameObjectsWithTag("Checkpoint");
        nrOfCheckpoints = arr.Length;

        for (int i = 0; i < nrOfCheckpoints; i++)
        {
            checkpoints.Add(arr[i]);
        }

	}
	
	// Update is called once per frame
	void Update () {

        //lap = currentLap;
	}
}
