using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDetect : MonoBehaviour {

    public GameObject Lhand;
    public GameObject Rhand;
    public GameObject Lelbow;
    public GameObject Relbow;
    public GameObject player;
    public GameObject head;
    public GameObject focus;
    public GameObject Left90;
    public GameObject Right90;
    
    public Transform aim;

    public Rigidbody rig;

    bool Gcheck1 = false;
    bool Gcheck2 = false;

    public float Rangle;
    public float Langle;
    float speed = 180f;
    float Midx;
    float Midy;
    float Midz;
    


    // Use this for initialization
    void Start () {
        rig = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Midx = (Lhand.transform.position.x + Rhand.transform.position.x) / 2;
        Midy =  (Lhand.transform.position.y + Rhand.transform.position.y) / 2;
        //Midz =  (Lhand.transform.position.z + Rhand.transform.position.z) / 2;

        focus.transform.position = new Vector3(Midx, Midy, 0);
        /*
        Vector3 targetDir = aim.position - player.transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(player.transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(player.transform.position, newDir, Color.red);
        */

        //Move Start
        //Debug.Log(Lhand.transform.position.x + "and " + Rhand.transform.position.x);
        if (Lhand.transform.position.x < head.transform.position.x && head.transform.position.x-3f < Lhand.transform.position.x && Rhand.transform.position.x > head.transform.position.x && head.transform.position.x+3f > Rhand.transform.position.x){
           //Debug.Log("Normal");
            if (Lhand.transform.position.y > Lelbow.transform.position.y && Rhand.transform.position.y > Relbow.transform.position.y){
                Gcheck1 = true;
            }
        }

        if(Gcheck1 == true){
            if (Lhand.transform.position.x > -2 && 1 > Lhand.transform.position.x && Rhand.transform.position.x > 1 && 3 > Rhand.transform.position.x){
                if (Lhand.transform.position.y < Lelbow.transform.position.y && Rhand.transform.position.y < Relbow.transform.position.y){
                    Gcheck2 = true;
                }
            }
        }      
                if (Gcheck1 == true && Gcheck2 == true){
            move();
        }

        //Move End

        //Rotate Start--Left
        if (Lhand.transform.position.x < head.transform.position.x && Rhand.transform.position.x < head.transform.position.x){
            //Debug.Log("turn Left");
            //player.transform.LookAt(aim);
            //player.transform.rotation = Quaternion.LookRotation(newDir);
            Left90.SendMessage("RotateLeft", SendMessageOptions.RequireReceiver);

        }
        //Rotate Start--Right
        if (Lhand.transform.position.x > head.transform.position.x && Rhand.transform.position.x > head.transform.position.x){
            //Debug.Log("turn Right");
            Right90.SendMessage("RotateRight", SendMessageOptions.RequireReceiver);

        }
    }
           
        
       
	

    void move(){

        
        //counter += 2f;
        //player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + counter);
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rig.MovePosition(rig.position + movement);
            //player.transform.position += Vector3.forward * Time.deltaTime * speed;
            
                Debug.Log("move forward");
                Gcheck1 = false;
                 Gcheck2 = false;
        
       
            }
     
    
    
}
