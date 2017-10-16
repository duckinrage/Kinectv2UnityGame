using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAngleDetect : MonoBehaviour {


    public Transform target;
   
    public GameObject player;
    public Rigidbody rig;
    public Quaternion turnRotation;
   // public float speed;
    // Use this for initialization
    void Start () {
        rig = player.GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetDir = Vector3.Normalize(target.position - transform.position);
        float leftA = targetDir.x;
        float rotY = player.transform.rotation.y;
         turnRotation = Quaternion.Euler(0f, Mathf.Lerp(rotY,rotY-90f,leftA)*Time.deltaTime, 0f);
        
    }
   public void RotateLeft()
    {
        rig.MoveRotation(rig.rotation * turnRotation);
    }

}

