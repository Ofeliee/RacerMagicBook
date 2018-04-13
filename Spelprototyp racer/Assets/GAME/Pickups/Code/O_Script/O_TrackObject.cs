using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_TrackObject : MonoBehaviour {
	public Transform target;
	public float distanceUp;
	public float distanceBack;
	public float minimumHeight;
    //New -Tim-
    public float heightDamping = 2.0f;
    public float rotationDamping = 2.0f;
    //---

	private Vector3 positionVelocity;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//calculate new position to place cam
		Vector3 newPosition = target.position + (target.forward * distanceBack);
		newPosition.y = Mathf.Max (newPosition.y + distanceUp, minimumHeight);

        //New -Tim-
     //   float newRotationAngle = target.eulerAngles.y;
       // float newHeight = target.position.y + minimumHeight;

      //  float currentRotationAngle = target.eulerAngles.y;
       // float currentHeight = target.position.y;

    //    currentRotationAngle = Mathf.Lerp(currentRotationAngle, newRotationAngle, rotationDamping * Time.deltaTime);
      //  currentHeight = Mathf.Lerp(currentHeight, newHeight, heightDamping * Time.deltaTime);
        //---

        //move
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref positionVelocity, 0.05f);

		//rotate cam to look where car is pointing:
		Vector3 focalPoint = target.position + (target.forward *5);
		transform.LookAt (focalPoint);

        //New -Tim-
        

	}
}
