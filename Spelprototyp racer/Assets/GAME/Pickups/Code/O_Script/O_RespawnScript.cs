using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_RespawnScript : MonoBehaviour {

	public Vector3 respawnLoc;
	// Use this for initialization
	void Start () 
	{
		respawnLoc = gameObject.GetComponent<Transform> ().position;
		respawnLoc.y += 10;

	}

	public void Respawn()
	{
		gameObject.GetComponent<Transform> ().position = respawnLoc;
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		gameObject.GetComponent<Movement> ().thrustForce = 20;
		gameObject.GetComponent<Transform>().Rotate(0, 0, 0);
		gameObject.GetComponent<sCollisionScript> ().hitCount = 0;
		GetComponentInChildren<MeshRenderer> ().material = gameObject.GetComponent<sCollisionScript> ().normalMat;
		gameObject.GetComponent<StockpileSpdPU> ().Reset ();
	}
}

