using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Test2 { }
public class sCollisionScript : MonoBehaviour
{
    public float hitCount = 0;
    public Material newMaterialref;
    public Material sMaterialref;
	public Material normalMat;
    public Renderer refRend;

	public bool respawning = false;

	public float count = 4f;
	private float timer = 0.0f;
	private Color inv;
	private bool invun = false;
	bool firstCol= true;

	void Start()
	{
		firstCol = true;
		inv = refRend.material.color;
	}
    private void OnCollisionEnter(Collision collisionInfo)
    {
		if (firstCol == true) 
		{
			normalMat = gameObject.GetComponentInChildren<MeshRenderer> ().material;
			refRend = gameObject.GetComponentInChildren<Renderer>();
			firstCol = false;
		}
        Debug.Log(collisionInfo.collider.name);

		if (timer < 0) 
		{
			
			if (collisionInfo.collider.tag == "Obstacle") 
			{
				hitCount++;

				if (hitCount == 1) 
				{
					refRend.material = newMaterialref;
				} 
				else if (hitCount == 2) 
				{
					refRend.material = sMaterialref;
				} 
				else if (hitCount == 3) 
				{
					respawning = true;
					gameObject.GetComponent<O_RespawnScript> ().Respawn ();
					//Destroy (gameObject);
				}
				timer = count;
				inv = refRend.material.color;
				inv.a = 0.5f;
				refRend.material.color = inv;
				invun = true;
			}
		}
    }


	void Update()
	{
		timer -= Time.deltaTime;

		if (invun ==true && timer < 0.00) 
		{
			inv = refRend.material.color;
			inv.a = 1.0f;
			refRend.material.color = inv;
			invun = false;
		}
			

	}

}
