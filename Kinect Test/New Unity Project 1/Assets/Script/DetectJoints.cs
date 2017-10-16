using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {

    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager BodyManager;
    private Body[] bodies;
    public float scale = 10f;

	// Use this for initialization
	void Start () {

        if(BodySrcManager == null){

            Debug.Log("Assign GameObj with BodySrcManager");
        }
        else{

            BodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {

		if(BodyManager == null){

            return;
        }

        bodies = BodyManager.GetData();

        if (bodies == null){

            return;
        }

        foreach( var body in bodies){

            if (body == null){

                continue;
            }

            if (body.IsTracked){

                var pos = body.Joints[TrackedJoint].Position;
                gameObject.transform.position = new Vector3(pos.X * scale, pos.Y * scale);

            }
        }


	}
}
