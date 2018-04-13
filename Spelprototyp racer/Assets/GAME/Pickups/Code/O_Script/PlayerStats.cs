using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float speed;
    public float hitCount;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = GetComponent<O_HoverController>().acceleration;
        hitCount = GetComponent<sCollisionScript>().hitCount;
	}
}
