using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_RespawnScript : MonoBehaviour {

	public Vector3 respawnLoc;
	public Quaternion respawnRot;
	public GameObject cam;
	// Use this for initialization
	void Start () 
	{
		respawnLoc = gameObject.GetComponent<Transform> ().position;
		respawnRot = gameObject.GetComponent<Transform> ().rotation;
		respawnLoc.y += 10;

	}

	public void Respawn()
	{
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		gameObject.GetComponent<Movement> ().thrustForce = 20;
		gameObject.GetComponent<Transform>().SetPositionAndRotation(respawnLoc, respawnRot);
		gameObject.GetComponent<sCollisionScript> ().hitCount = 0;
		GetComponentInChildren<MeshRenderer> ().material = gameObject.GetComponent<sCollisionScript> ().normalMat;
		gameObject.GetComponent<StockpileSpdPU> ().Reset ();
	}
}

