using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAngleDetect : MonoBehaviour {

    public Transform targetR;
    
    public GameObject playerR;
    public Rigidbody rigR;
    public Quaternion turnRotationR;
    //public float speed;


	// Use this for initialization
	void Start () {
        rigR = playerR.GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetDir = Vector3.Normalize(transform.position - targetR.position);
        float rightA = targetDir.x;
        //Debug.Log(rightA);
        float rotY = playerR.transform.rotation.y;
        turnRotationR = Quaternion.Euler(0f, Mathf.Lerp(rotY, rotY+90f, rightA) * Time.deltaTime, 0f);
  
	}

    public void RotateRight()
    {
        
        rigR.MoveRotation(rigR.rotation * turnRotationR);
    }
}
