using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public Transform target;
    public Vector3 offset;

    public float pitch;
    private float currentZoom = 10f;

	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
	}
}
