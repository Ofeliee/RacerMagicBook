using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_RespawnScript : MonoBehaviour {

	public Vector3 respawnLoc;
	// Use this for initialization
	void Start () 
	{
		respawnLoc = gameObject.GetComponent<Transform> ().position;
		respawnLoc.y += 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.GetComponent<sCollisionScript> ().hitCount == 3) 
		{
			gameObject.GetComponent<Transform> ().position = respawnLoc;
			gameObject.GetComponent<sCollisionScript> ().hitCount = 0;
		}
	}
}
