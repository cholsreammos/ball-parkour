using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float speed = 10.0F;
	public float rotateSpeed = 5.0F;
	public Rigidbody RB;
	public float JumpSpeed = 7.5F;
	public bool canJump = false;
	public bool spaceBarDown;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space)){
			spaceBarDown = true;
		}
	}
	
	void FixedUpdate()
	{
		TouchingFloor();
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		float curSpeedV = speed * Input.GetAxis("Vertical");
		RB.AddForce(forward * curSpeedV, ForceMode.Force);
		Vector3 right = transform.TransformDirection(Vector3.right);
		float curSpeedH = speed * Input.GetAxis("Horizontal");
		RB.AddForce(right * curSpeedH, ForceMode.Force);
        float curSpeedRH = rotateSpeed * Input.GetAxis("RotateHorizontal");
		transform.Rotate(0,(float)0.25 * curSpeedRH,0);
		if ((spaceBarDown == true) && canJump == true){
			RB.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
			spaceBarDown = false;
		}
		if ((spaceBarDown == true) && canJump == false){
			spaceBarDown = false;
		}
	}
	
	void OnTriggerStay(Collider other){
		if (other.tag == "speedBoost"){
			speed = 30.0F;
		}
		
		if (other.tag == "noJump"){
			JumpSpeed = 0.0F;
		}
			
		if (other.tag == "momentumStop"){
			Vector3 stop = new Vector3((float)0.25 * RB.velocity.x,-1,(float)0.25 * RB.velocity.z);
			RB.velocity = stop;
		}
		
	}

	void OnTriggerExit(Collider other){
		speed = 10.0F;
		JumpSpeed = 7.5F;
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.layer == 3){
			Physics.IgnoreCollision(other.collider,RB.GetComponent<Collider>());
		}
	}
	
	bool TouchingFloor(){
		Vector3 sphereLocation = RB.transform.position;
		sphereLocation.y -= (float)0.4;
		Vector3 sphereRotation = new Vector3(0,0,0);
		Vector3 boxSize = new Vector3((float)0.375,(float)0.2,(float)0.375);
		Debug.Log(Physics.BoxCast(sphereLocation,boxSize,sphereRotation,Quaternion.identity,Mathf.Infinity,55));
		return canJump;
	}
	
	void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
		Vector3 sphereLocation = RB.transform.position;
		sphereLocation.y -= (float)0.4;
		Vector3 boxSize = new Vector3((float)0.375,(float)0.2,(float)0.375);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(sphereLocation, boxSize * 2);
    }
}
